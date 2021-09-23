using Infrastructure;
using Model.ClassesModel.DTO;
using Model.GroupSModel.DTO;
using Model.LessonModel.DTO;
using Model.MaterialModel.DTO;
using Model.MaterialModel.Entity;
using Model.MaterialModel.Repository;
using Model.SchoolModel.DTO;
using Model.SubjectModel.DTO;
using Model.TeacherModel.DTO;
using Model.UserModel.DTO;
using Persistance.InfrastructureRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.MaterialRepository
{
    public class MaterialRepository : NHCrudRepository<Material>, IMaterialRepository
    {
        public MaterialRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public IList<Material> GetAll()
        {
            return NHUnitOfWork.Session.Query<Material>().ToList<Material>();
        }

        public IList<MaterialDTO> GetAllDTO()
        {
            return NHUnitOfWork.Session.Query<Material>()
                .Select(x => new MaterialDTO()
                {
                    Id = x.Id,
                    Classes = new ClassesDTO()
                    {
                        Id = x.Classes.Id,
                        Lesson = new LessonDTO()
                        {
                            Id = x.Classes.Lesson.Id,
                            GroupS = new GroupSDTO()
                            {
                                Id = x.Classes.Lesson.GroupS.Id,
                                Year = x.Classes.Lesson.GroupS.Year,
                                Semester = x.Classes.Lesson.GroupS.Semester,
                                Direction = x.Classes.Lesson.GroupS.Direction,
                                Specjalize = x.Classes.Lesson.GroupS.Specjalize,
                            },
                            Teacher = new TeacherDTO()
                            {
                                Id = x.Classes.Lesson.Teacher.Id,
                                user = new UserDTO()
                                {
                                    Id = x.Classes.Lesson.Teacher.Users.Id,
                                    Login = x.Classes.Lesson.Teacher.Users.Login,
                                    ImieNazwisko = x.Classes.Lesson.Teacher.Users.ImieNazwisko,
                                    CzyAktywny = x.Classes.Lesson.Teacher.Users.CzyAktywny,
                                    Password = x.Classes.Lesson.Teacher.Users.Password,
                                    Email = x.Classes.Lesson.Teacher.Users.Email,
                                    Rola = new RolaDTO()
                                    {
                                        Id = x.Classes.Lesson.Teacher.Users.Rola.Id,
                                        Nazwa = x.Classes.Lesson.Teacher.Users.Rola.Nazwa
                                    },
                                    School = new SchoolDTO()
                                    {
                                        Id = x.Classes.Lesson.Teacher.Users.School.Id,
                                        Name = x.Classes.Lesson.Teacher.Users.School.Name,
                                        Logo = x.Classes.Lesson.Teacher.Users.School.Logo
                                    },
                                    NrIndex = x.Classes.Lesson.Teacher.Users.NrIndex,
                                    Image = x.Classes.Lesson.Teacher.Users.Image,
                                    GroupS = new GroupSDTO(),
                                },
                                Specjalize = x.Classes.Lesson.Teacher.Specjalize
                            },
                            Subject = new SubjectDTO()
                            {
                                Id = x.Classes.Lesson.Subject.Id,
                                Name = x.Classes.Lesson.Subject.Name
                            },
                            TypLesson = x.Classes.Lesson.TypLesson,
                            Time = x.Classes.Lesson.Time
                        },
                        Theme = x.Classes.Theme,
                        DataClasses = x.Classes.DataClasses,
                    },
                    Localization = x.Localization,
                    Name = x.Name,
                    IsActive = x.IsActive,
                    DataActive = x.DataActive
                })
            .ToList<MaterialDTO>();
        }

        public IList<Material> GetAllFileGroup(Guid id)
        {
            return NHUnitOfWork.Session.Query<Material>()
                .Where(x => x.Classes.Lesson.GroupS.Id == id)
                .ToList<Material>();
        }

        public IList<MaterialDTO> GetAllFromClasses(Guid id)
        {
            return NHUnitOfWork.Session.Query<Material>()
                .Where(x => x.Classes.Id == id)
                .Select(x => new MaterialDTO()
                {
                    Id = x.Id,
                    Classes = new ClassesDTO()
                    {
                        Id = x.Classes.Id,
                        Lesson = new LessonDTO()
                        {
                            Id = x.Classes.Lesson.Id,
                            GroupS = new GroupSDTO()
                            {
                                Id = x.Classes.Lesson.GroupS.Id,
                                Year = x.Classes.Lesson.GroupS.Year,
                                Semester = x.Classes.Lesson.GroupS.Semester,
                                Direction = x.Classes.Lesson.GroupS.Direction,
                                Specjalize = x.Classes.Lesson.GroupS.Specjalize,
                            },
                            Teacher = new TeacherDTO()
                            {
                                Id = x.Classes.Lesson.Teacher.Id,
                                user = new UserDTO()
                                {
                                    Id = x.Classes.Lesson.Teacher.Users.Id,
                                    Login = x.Classes.Lesson.Teacher.Users.Login,
                                    ImieNazwisko = x.Classes.Lesson.Teacher.Users.ImieNazwisko,
                                    CzyAktywny = x.Classes.Lesson.Teacher.Users.CzyAktywny,
                                    Password = x.Classes.Lesson.Teacher.Users.Password,
                                    Email = x.Classes.Lesson.Teacher.Users.Email,
                                    Rola = new RolaDTO()
                                    {
                                        Id = x.Classes.Lesson.Teacher.Users.Rola.Id,
                                        Nazwa = x.Classes.Lesson.Teacher.Users.Rola.Nazwa
                                    },
                                    School = new SchoolDTO()
                                    {
                                        Id = x.Classes.Lesson.Teacher.Users.School.Id,
                                        Name = x.Classes.Lesson.Teacher.Users.School.Name,
                                        Logo = x.Classes.Lesson.Teacher.Users.School.Logo
                                    },
                                    NrIndex = x.Classes.Lesson.Teacher.Users.NrIndex,
                                    Image = x.Classes.Lesson.Teacher.Users.Image,
                                    GroupS = new GroupSDTO(),
                                },
                                Specjalize = x.Classes.Lesson.Teacher.Specjalize
                            },
                            Subject = new SubjectDTO()
                            {
                                Id = x.Classes.Lesson.Subject.Id,
                                Name = x.Classes.Lesson.Subject.Name
                            },
                            TypLesson = x.Classes.Lesson.TypLesson,
                            Time = x.Classes.Lesson.Time
                        },
                        Theme = x.Classes.Theme,
                        DataClasses = x.Classes.DataClasses,
                    },
                    Localization = x.Localization,
                    Name = x.Name,
                    IsActive = x.IsActive,
                    DataActive = x.DataActive
                })
            .ToList<MaterialDTO>();
        }

        public IList<Material> GetAllNieaktywne()
        {
            return NHUnitOfWork.Session.Query<Material>()
                 .Where(x => x.IsActive == false)
                 .ToList<Material>();
        }

        public MaterialDTO GetDTO(Guid id)
        {
            return NHUnitOfWork.Session.Query<Material>()
                .Where(x => x.Id == id)
                .Select(x => new MaterialDTO()
                {
                    Id = x.Id,
                    Classes = new ClassesDTO()
                    {
                        Id = x.Classes.Id,
                        Lesson = new LessonDTO()
                        {
                            Id = x.Classes.Lesson.Id,
                            GroupS = new GroupSDTO()
                            {
                                Id = x.Classes.Lesson.GroupS.Id,
                                Year = x.Classes.Lesson.GroupS.Year,
                                Semester = x.Classes.Lesson.GroupS.Semester,
                                Direction = x.Classes.Lesson.GroupS.Direction,
                                Specjalize = x.Classes.Lesson.GroupS.Specjalize,
                            },
                            Teacher = new TeacherDTO()
                            {
                                Id = x.Classes.Lesson.Teacher.Id,
                                user = new UserDTO()
                                {
                                    Id = x.Classes.Lesson.Teacher.Users.Id,
                                    Login = x.Classes.Lesson.Teacher.Users.Login,
                                    ImieNazwisko = x.Classes.Lesson.Teacher.Users.ImieNazwisko,
                                    CzyAktywny = x.Classes.Lesson.Teacher.Users.CzyAktywny,
                                    Password = x.Classes.Lesson.Teacher.Users.Password,
                                    Email = x.Classes.Lesson.Teacher.Users.Email,
                                    Rola = new RolaDTO()
                                    {
                                        Id = x.Classes.Lesson.Teacher.Users.Rola.Id,
                                        Nazwa = x.Classes.Lesson.Teacher.Users.Rola.Nazwa
                                    },
                                    School = new SchoolDTO()
                                    {
                                        Id = x.Classes.Lesson.Teacher.Users.School.Id,
                                        Name = x.Classes.Lesson.Teacher.Users.School.Name,
                                        Logo = x.Classes.Lesson.Teacher.Users.School.Logo
                                    },
                                    NrIndex = x.Classes.Lesson.Teacher.Users.NrIndex,
                                    Image = x.Classes.Lesson.Teacher.Users.Image,
                                    GroupS = new GroupSDTO(),
                                },
                                Specjalize = x.Classes.Lesson.Teacher.Specjalize
                            },
                            Subject = new SubjectDTO()
                            {
                                Id = x.Classes.Lesson.Subject.Id,
                                Name = x.Classes.Lesson.Subject.Name
                            },
                            TypLesson = x.Classes.Lesson.TypLesson,
                            Time = x.Classes.Lesson.Time
                        },
                        Theme = x.Classes.Theme,
                        DataClasses = x.Classes.DataClasses,
                    },
                    Localization = x.Localization,
                    Name = x.Name,
                    IsActive = x.IsActive,
                    DataActive = x.DataActive
                })
            .FirstOrDefault();
        }

        public IList<MaterialDTO> GetFromSchool(Guid id)
        {
            return NHUnitOfWork.Session.Query<Material>()
                .Where(x => x.Classes.Lesson.Subject.School.Id == id)
                .Select(x => new MaterialDTO()
                {
                    Id = x.Id,
                    Classes = new ClassesDTO()
                    {
                        Id = x.Classes.Id,
                        Lesson = new LessonDTO()
                        {
                            Id = x.Classes.Lesson.Id,
                            GroupS = new GroupSDTO()
                            {
                                Id = x.Classes.Lesson.GroupS.Id,
                                Year = x.Classes.Lesson.GroupS.Year,
                                Semester = x.Classes.Lesson.GroupS.Semester,
                                Direction = x.Classes.Lesson.GroupS.Direction,
                                Specjalize = x.Classes.Lesson.GroupS.Specjalize,
                            },
                            Teacher = new TeacherDTO()
                            {
                                Id = x.Classes.Lesson.Teacher.Id,
                                user = new UserDTO()
                                {
                                    Id = x.Classes.Lesson.Teacher.Users.Id,
                                    Login = x.Classes.Lesson.Teacher.Users.Login,
                                    ImieNazwisko = x.Classes.Lesson.Teacher.Users.ImieNazwisko,
                                    CzyAktywny = x.Classes.Lesson.Teacher.Users.CzyAktywny,
                                    Password = x.Classes.Lesson.Teacher.Users.Password,
                                    Email = x.Classes.Lesson.Teacher.Users.Email,
                                    Rola = new RolaDTO()
                                    {
                                        Id = x.Classes.Lesson.Teacher.Users.Rola.Id,
                                        Nazwa = x.Classes.Lesson.Teacher.Users.Rola.Nazwa
                                    },
                                    School = new SchoolDTO()
                                    {
                                        Id = x.Classes.Lesson.Teacher.Users.School.Id,
                                        Name = x.Classes.Lesson.Teacher.Users.School.Name,
                                        Logo = x.Classes.Lesson.Teacher.Users.School.Logo
                                    },
                                    NrIndex = x.Classes.Lesson.Teacher.Users.NrIndex,
                                    Image = x.Classes.Lesson.Teacher.Users.Image,
                                    GroupS = new GroupSDTO(),
                                },
                                Specjalize = x.Classes.Lesson.Teacher.Specjalize
                            },
                            Subject = new SubjectDTO()
                            {
                                Id = x.Classes.Lesson.Subject.Id,
                                Name = x.Classes.Lesson.Subject.Name
                            },
                            TypLesson = x.Classes.Lesson.TypLesson,
                            Time = x.Classes.Lesson.Time
                        },
                        Theme = x.Classes.Theme,
                        DataClasses = x.Classes.DataClasses,
                    },
                    Localization = x.Localization,
                    Name = x.Name,
                    IsActive = x.IsActive,
                    DataActive = x.DataActive
                })
            .ToList<MaterialDTO>();
        }

        public IList<MaterialInfoDTO> GetInfoMaterialFromClasses(Guid id)
        {
            return NHUnitOfWork.Session.Query<Material>()
                .Where(x => x.Classes.Id == id)
                .Select(x => new MaterialInfoDTO()
                {
                    Id = x.Id,
                    Localization = x.Localization,
                    Name = x.Name,
                    IsActive = x.IsActive,
                    DataActive = x.DataActive
                })
            .ToList<MaterialInfoDTO>();
        }

        public List<MaterialFileDTO> getMaterialClas(Guid id)
        {
            IList<MaterialFileDTO> mat = NHUnitOfWork.Session.Query<Material>()
                .Where(x => x.Classes.Id == id)
                .Select(x => new MaterialFileDTO()
                {
                    Id = x.Id,
                    Localization = x.Localization,
                    Name = x.Name,
                    IsActive = x.IsActive,
                    DataActive = x.DataActive
                })
            .ToList<MaterialFileDTO>();

            List<MaterialFileDTO> materials = new List<MaterialFileDTO>();
            if (mat != null)
            {
                foreach (MaterialFileDTO m in mat)
                {
                    materials.Add(m);
                }
            }

            return materials;
        }
    }
}
