using ExpressMapper.Extensions;
using Infrastructure;
using Infrastructure.Security;
using Microsoft.Extensions.Logging;
using Model.ClassesModel.DTO;
using Model.GroupSModel.DTO;
using Model.GroupSModel.Entity;
using Model.GroupSModel.Repository;
using Model.LessonModel.DTO;
using Model.LessonModel.Repository;
using Model.MaterialModel.DTO;
using Model.MaterialModel.Entity;
using Model.MaterialModel.Repository;
using Model.SchoolModel.DTO;
using Model.SchoolModel.Entity;
using Model.SchoolModel.Repository;
using Model.SubjectModel.DTO;
using Model.TeacherModel.DTO;
using Model.UserModel.Const;
using Model.UserModel.DTO;
using Model.UserModel.Entity;
using Model.UserModel.IService;
using Model.UserModel.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Model.UserModel.Service
{
    public class UserService : ApplicationService, IUserService
    {

        private readonly IUserRepository userRepository;
        private readonly IPasswordHasher passwordHasher;
        private readonly IRolaRepository rolaRepository;
        private readonly ISchoolRepository schoolRepository;
        private readonly IGroupSRepository groupSRepository;
        private readonly ILessonRepository lessonRepository;
        private readonly IMaterialRepository materialRepository;
        private readonly ILogger<UserService> logger;

        public UserService(IUnitOfWork unitOfWork,
            ILogger<UserService> logger,
            IUserRepository userRepository,
            IPasswordHasher passwordHasher,
            IRolaRepository rolaRepository,
            ISchoolRepository schoolRepository,
            IGroupSRepository groupSRepository,
            ILessonRepository lessonRepository,
            IMaterialRepository materialRepository
            )
            : base(unitOfWork)
        {
            this.logger = logger;
            this.passwordHasher = passwordHasher;
            this.userRepository = userRepository;
            this.rolaRepository = rolaRepository;
            this.schoolRepository = schoolRepository;
            this.groupSRepository = groupSRepository;
            this.lessonRepository = lessonRepository;
            this.materialRepository = materialRepository;
        }
        public void AktywujUzytkownika(string login, string userName)
        {
            Users uzytkownik = userRepository.GetByLogin(login);
            if (uzytkownik == null)
                throw new Exception("Nie można aktywować użytkownika, niepoprawny login");

            uzytkownik.CzyAktywny = true;
            uzytkownik.SetAuditModified(userName);
            uzytkownik.Validate();
            userRepository.Update(uzytkownik);
        }

        public void DezaktywujUzytkownika(string login, string userName)
        {
            Users uzytkownik = userRepository.GetByLogin(login);
            if (uzytkownik == null)
                throw new Exception("Nie można dezaktywować użytkownika, niepoprawny login");

            uzytkownik.CzyAktywny = false;
            uzytkownik.SetAuditModified(userName);
            uzytkownik.Validate();
            userRepository.Update(uzytkownik);
        }

        public Guid DodajUzytkownika(UserDTO dto, string userName)
        {
            if (userRepository.SprawdzCzyLoginIstnieje(dto.Login))
                throw new ValidationException($"Nie można dodać użytkownika {dto.Login}, gdyż użytkownik o takim loginie już istnieje.");

            Rola rola = rolaRepository.Get(dto.Rola.Id);
            if (rola == null)
                throw new BusinessException("Nie można dodać użytkownka gdyż brak wskazanej roli");

            School school = schoolRepository.GetSchool(dto.School.Id);
            /*
            Users uzytkownik = new Users(
                Guid.NewGuid(),
                dto.Login,
                passwordHasher.Hash(dto.Login, dto.Password),
                dto.ImieNazwisko,
                dto.CzyAktywny,
                dto.Email,
                rola,
                school,
                new AuditData(userName, DateTime.Now),
                dto.Image)
            { };

            uzytkownik.Validate();

            Guid id = userRepository.Add(uzytkownik);

            return id;*/

            return Guid.Empty;
        }

        public void EdytujUzytkownika(UserDTO dto, string userName)
        {
            if (userRepository.SprawdzCzyLoginIstnieje(dto.Login, dto.Id))
                throw new ValidationException($"Nie można edytować użytkownika {dto.Login}, gdyż użytkownik o takim loginie już istnieje.");

            Rola rola = rolaRepository.Get(dto.Rola.Id);
            if (rola == null)
                throw new BusinessException("Nie można edytować użytkownka gdyż brak wskazanej roli");

            var result = userRepository.Get(dto.Id);
            dto.Map<UserDTO, Users>(result);
            result.Rola = rola;
            result.SetAuditModified(userName);
            result.Validate();

            userRepository.Update(result);
        }

        public ClaimsIdentity Login(string login, string password)
        {
            logger.LogDebug($"Log on user {login}");
            Users uzytkownik = userRepository.GetByLogin(login);

            if (uzytkownik == null)
                throw new BusinessException("Login niepoprawny");

            if (!(uzytkownik.CzyAktywny && uzytkownik.Password == passwordHasher.Hash(login, password)))
            {
                logger.LogWarning($"Nastąpiła nieudana próba logowania na użytkownika {login}");
                throw new BusinessException("Login lub hasło niepoprawne");
            }
            uzytkownik.Validate();

            List<Claim> claims = GetUserClaims(uzytkownik);

            var identity = new ClaimsIdentity(
                new System.Security.Principal.GenericIdentity(uzytkownik.Login, "Token"),
                claims
                );
            return identity;
        }

        private List<Claim> GetUserClaims(Users user)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(UserConsts.UserId, user.Id.ToString()));
            claims.Add(new Claim(UserConsts.UserFullName, user.Login));
            claims.Add(new Claim(UserConsts.RolaName, user.Rola.Nazwa));
            return claims;
        }

        public IList<UserDTO> PobierzListeUzytkownikowByRola(string rola)
        {
            var result = userRepository.PobierzListeUzytkownikowByRola(rola);
            return result.Map<IEnumerable<Users>, List<UserDTO>>();
        }

        public UserDTO PobierzUzytkownika(Guid id)
        {
            var result = userRepository.Get(id);
            if (result != null)
            {
                UserDTO dto = result.Map<Users, UserDTO>();
                return dto;
            }

            return null;
        }

        public IList<UserDTO> PobietrzListeKlientow()
        {
            return userRepository.PobierzLiteKlientow().ToList();
        }

        public void UsunUzytkownika(Guid id)
        {
            userRepository.Delete(id);
        }

        public void ChangePassword(Guid id, string haslo, string noweHaslo, string noweHaslo2)
        {
            if (string.IsNullOrEmpty(haslo))
                throw new ArgumentNullException("haslo");
            if (string.IsNullOrEmpty(noweHaslo))
                throw new ArgumentNullException("noweHaslo");

            if (noweHaslo != noweHaslo2)
                throw new Exception("Nie można zmienić hasła użytkownika, gdyż nowe hasła są różne");

            Users uzytkownik = userRepository.Get(id);
            if (uzytkownik == null)
                throw new Exception("Nie można zmienić hasła użytkownika, gdyż login lub hasło jest niepoprawne");

            if (uzytkownik.Password != passwordHasher.Hash(uzytkownik.Login, haslo))
                throw new Exception("Nie można zmienić hasła użytkownika, gdyż login lub hasło jest niepoprawne");

            uzytkownik.Password = passwordHasher.Hash(uzytkownik.Login, noweHaslo);

            uzytkownik.Validate();
            userRepository.Update(uzytkownik);
        }

        public IList<UserDTO> PobietrzListePracownikow()
        {
            return userRepository.PobierzLitePracownikow().ToList();
        }

        public bool SprawdzCzyLoginIstnieje(string login, Guid id)
        {
            return this.userRepository.SprawdzCzyLoginIstnieje(login, id);
        }

        public IList<UserDTO> getAllDTO()
        {
            IList<UserDTO> users = userRepository.GetAllDTO();
            return users;
        }

        public Guid AddUser(Users users)
        {
            if (userRepository.SprawdzCzyLoginIstnieje(users.Login))
                throw new ValidationException($"Nie można dodać użytkownika {users.Login}, gdyż użytkownik o takim loginie już istnieje.");

            Rola rola = rolaRepository.Get(users.Rola.Id);
            if (rola == null)
                throw new BusinessException("Nie można dodać użytkownka gdyż brak wskazanej roli");

            users.Validate();

            Guid id = userRepository.Add(users);

            return id;
        }

        public IList<Users> getAll()
        {
            return userRepository.GetAll();
        }

        public Guid AddAdministration(UserDTO dto, Guid id)
        {
            Rola rola = rolaRepository.Get(new Guid("187CE7AB-101D-450F-8503-BE95A28B5854"));
            School school = schoolRepository.GetSchool(id);


            Users user = new Users(dto.Id, dto.Login, dto.Password, dto.ImieNazwisko, true, dto.Email, rola, school, new AuditData("system", DateTime.Now));

            user.Validate();
            return userRepository.Add(user);

        }

        public IList<UserDTO> getUserSchool(Guid id)
        {
            return userRepository.getUserSchool(id);
        }

        public List<UserStudentDTO> GetStudentsFromGroup(Guid id)
        {
            List<UserStudentDTO> group = new List<UserStudentDTO>();
            IList<UserStudentDTO> list = userRepository.GetStudentsFromGroup(id);

            foreach (var e in list)
            {
                group.Add(e);
            }

            return group;
        }

        public void NewStudent(NewStudentDTO dto)
        {
            Users users = userRepository.Get(dto.IdUser);
            Rola rola = rolaRepository.Get(Guid.Parse("75944EBD-854D-4ACE-B991-9471E98C9233"));
            GroupS group = groupSRepository.Get(dto.IdGroup);
            Random _rdm = new Random();
            users.GroupS = group;
            users.Rola = rola;
            users.NrIndex = _rdm.Next(1000, 9999);
            userRepository.Update(users);
        }

        public StudentDTO GetStudent(Guid id)
        {
            Users users = userRepository.Get(id);
            List<UserStudentDTO> userStudents = GetStudentsFromGroup(users.GroupS.Id);
            IList<LessonDTO> lessons = lessonRepository.GetLessonsFromGroup(users.GroupS.Id);
            IList<Material> materials = materialRepository.GetAllFileGroup(users.GroupS.Id);

            StudentDTO student = new StudentDTO();
            student.Id = users.Id;
            student.Login = users.Login;
            student.ImieNazwisko = users.ImieNazwisko;
            student.Email = users.Email;
            student.NrIndex = users.NrIndex;
            student.School = new SchoolDTO()
            {
                Id = users.School.Id,
                Name = users.School.Name,
                Logo = users.School.Logo
            };
            student.Group = new GroupStaticDTO()
            {
                Id = users.GroupS.Id,
                Direction = users.GroupS.Direction,
                Specjalize = users.GroupS.Specjalize,
                Year = users.GroupS.Year,
                Semester = users.GroupS.Semester,
                UserStudent = userStudents
            };

            student.Subject = new List<SubjectTypStudentDTO>();
            foreach (var les in lessons)
            {
                if (student.Subject.Exists(t => t.Id == les.Subject.Id) == false)
                {
                    SubjectTypStudentDTO subject = new SubjectTypStudentDTO();

                    subject.Id = les.Subject.Id;
                    subject.Name = les.Subject.Name;

                    subject.typs = new List<TypsLessonStudentDTO>();
                    TypsLessonStudentDTO typsLesson = new TypsLessonStudentDTO();
                    typsLesson.Name = GetTypeName(les.TypLesson);

                    typsLesson.lessonTyps = new List<LessonTypsDTO>();
                    LessonTypsDTO lesson = new LessonTypsDTO();
                    lesson.Id = les.Id;
                    lesson.userTeacher = new TeacherInfoDTO()
                    {
                        Id = les.Teacher.Id,
                        user = new UserTeacherDTO()
                        {
                            Id = les.Teacher.user.Id,
                            Login = les.Teacher.user.Login,
                            ImieNazwisko = les.Teacher.user.ImieNazwisko,
                            Email = les.Teacher.user.Email
                        },
                        Specjalize = les.Teacher.Specjalize
                    };

                    typsLesson.lessonTyps.Add(lesson);
                    subject.typs.Add(typsLesson);
                    student.Subject.Add(subject);
                }
                else
                {
                    SubjectTypStudentDTO subject = student.Subject.Where(t => t.Id == les.Subject.Id).FirstOrDefault();
                    student.Subject.Remove(subject);

                    if (subject.typs.Exists(t => t.Name == GetTypeName(les.TypLesson)) == false)
                    {
                        TypsLessonStudentDTO typsLesson = new TypsLessonStudentDTO();
                        typsLesson.Name = GetTypeName(les.TypLesson);
                        typsLesson.lessonTyps = new List<LessonTypsDTO>();
                        LessonTypsDTO lesson = new LessonTypsDTO();
                        lesson.Id = les.Id;
                        lesson.userTeacher = new TeacherInfoDTO()
                        {
                            Id = les.Teacher.Id,
                            user = new UserTeacherDTO()
                            {
                                Id = les.Teacher.user.Id,
                                Login = les.Teacher.user.Login,
                                ImieNazwisko = les.Teacher.user.ImieNazwisko,
                                Email = les.Teacher.user.Email
                            },
                            Specjalize = les.Teacher.Specjalize
                        };
                        typsLesson.lessonTyps.Add(lesson);
                        subject.typs.Add(typsLesson);
                    }
                    else
                    {
                        TypsLessonStudentDTO typsLesson = subject.typs.Where(t => t.Name == GetTypeName(les.TypLesson)).FirstOrDefault();
                        subject.typs.Remove(typsLesson);

                        //if (typsLesson.lessonTyps.Exists(t => t.Id == les.Id) == false)
                        //{
                        LessonTypsDTO lesson = new LessonTypsDTO();
                        lesson.Id = les.Id;
                        lesson.userTeacher = new TeacherInfoDTO()
                        {
                            Id = les.Teacher.Id,
                            user = new UserTeacherDTO()
                            {
                                Id = les.Teacher.user.Id,
                                Login = les.Teacher.user.Login,
                                ImieNazwisko = les.Teacher.user.ImieNazwisko,
                                Email = les.Teacher.user.Email
                            },
                            Specjalize = les.Teacher.Specjalize
                        };
                        typsLesson.lessonTyps.Add(lesson);
                        //}
                        //else
                        //{
                        //    LessonTypsDTO lesson = typsLesson.lessonTyps.Where(t => t.Id == les.Id).FirstOrDefault();
                        //    typsLesson.lessonTyps.Remove(lesson);

                        //    lesson.

                        //    typsLesson.lessonTyps.Add(lesson);
                        //}

                        subject.typs.Add(typsLesson);
                    }


                    student.Subject.Add(subject);
                }
            }

            student.Materials = new List<MaterialStudentDTO>();
            foreach (var mat in materials)
            {

                MaterialStudentDTO material = new MaterialStudentDTO();

                material.Id = mat.Id;
                material.Name = mat.Name;
                material.Localization = mat.Localization;
                material.DataActive = mat.DataActive;
                material.classesStudent = new ClassesStudentDTO();
                material.classesStudent.Id = mat.Classes.Id;
                material.classesStudent.Theme = mat.Classes.Theme;
                material.classesStudent.DataClasses = mat.Classes.DataClasses;
                material.classesStudent.lessonStudent = new LessonStudentDTO();
                material.classesStudent.lessonStudent.Id = mat.Classes.Lesson.Id;
                material.classesStudent.lessonStudent.UserTeacher = new TeacherInfoDTO();
                material.classesStudent.lessonStudent.UserTeacher.Id = mat.Classes.Lesson.Teacher.Id;
                material.classesStudent.lessonStudent.UserTeacher.Specjalize = mat.Classes.Lesson.Teacher.Specjalize;

                material.classesStudent.lessonStudent.UserTeacher.user = new UserTeacherDTO();
                material.classesStudent.lessonStudent.UserTeacher.user.Id = mat.Classes.Lesson.Teacher.Users.Id;
                material.classesStudent.lessonStudent.UserTeacher.user.ImieNazwisko = mat.Classes.Lesson.Teacher.Users.ImieNazwisko;
                material.classesStudent.lessonStudent.UserTeacher.user.Login = mat.Classes.Lesson.Teacher.Users.Login;
                material.classesStudent.lessonStudent.UserTeacher.user.Email = mat.Classes.Lesson.Teacher.Users.Email;

                material.classesStudent.lessonStudent.SubjectStudent = new SubjectStudentDTO();
                material.classesStudent.lessonStudent.SubjectStudent.Id = mat.Classes.Lesson.Subject.Id;
                material.classesStudent.lessonStudent.SubjectStudent.Name = mat.Classes.Lesson.Subject.Name;

                material.classesStudent.lessonStudent.Typ = GetTypeName(mat.Classes.Lesson.TypLesson);
                material.classesStudent.lessonStudent.Time = mat.Classes.Lesson.Time;

                student.Materials.Add(material);

            }


            return student;
        }

        public string GetTypeName(int typ)
        {
            if (typ == 0)
            {
                return "Wyklad";
            }
            if (typ == 1)
            {
                return "Ćwiczenia";
            }
            if (typ == 2)
            {
                return "Projekt";
            }
            return null;
        }
    }
}
