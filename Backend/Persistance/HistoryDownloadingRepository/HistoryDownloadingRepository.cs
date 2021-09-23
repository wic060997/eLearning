using Infrastructure;
using Model.ClassesModel.DTO;
using Model.GroupSModel.DTO;
using Model.HistoryDownloadingModel.DTO;
using Model.HistoryDownloadingModel.Entity;
using Model.HistoryDownloadingModel.Repository;
using Model.LessonModel.DTO;
using Model.MaterialModel.DTO;
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

namespace Persistance.HistoryDownloadingRepository
{
    public class HistoryDownloadingRepository : NHCrudRepository<HistoryDownloading>, IHistoryDownloadingRepository
    {
        public HistoryDownloadingRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public IList<HistoryDownloading> GetAll()
        {
            return NHUnitOfWork.Session.Query<HistoryDownloading>().ToList<HistoryDownloading>();
        }

        public IList<HistoryDTO> GetAllDTO()
        {
            return NHUnitOfWork.Session.Query<HistoryDownloading>()
                .Select(x => new HistoryDTO()
                {
                    Id = x.Id,
                    User = new UserDTO()
                    {
                        Id = x.Users.Id,
                        Login = x.Users.Login,
                        ImieNazwisko = x.Users.ImieNazwisko,
                        CzyAktywny = x.Users.CzyAktywny,
                        Password = x.Users.Password,
                        Email = x.Users.Email,
                        Rola = new RolaDTO()
                        {
                            Id = x.Users.Rola.Id,
                            Nazwa = x.Users.Rola.Nazwa
                        },
                        School = new SchoolDTO()
                        {
                            Id = x.Users.School.Id,
                            Name = x.Users.School.Name,
                            Logo = x.Users.School.Logo
                        },
                        NrIndex = x.Users.NrIndex,
                        Image = x.Users.Image,
                        GroupS = new GroupSDTO()
                        {
                            Id = x.Users.GroupS.Id,
                            Year = x.Users.GroupS.Year,
                            Semester = x.Users.GroupS.Semester,
                            Direction = x.Users.GroupS.Direction,
                            Specjalize = x.Users.GroupS.Specjalize,
                        }
                    },
                    Material = new MaterialDTO()
                    {
                        Id = x.Material.Id,
                        Classes = new ClassesDTO()
                        {
                            Id = x.Material.Classes.Id,
                            Lesson = new LessonDTO()
                            {
                                Id = x.Material.Classes.Lesson.Id,
                                GroupS = new GroupSDTO()
                                {
                                    Id = x.Material.Classes.Lesson.GroupS.Id,
                                    Year = x.Material.Classes.Lesson.GroupS.Year,
                                    Semester = x.Material.Classes.Lesson.GroupS.Semester,
                                    Direction = x.Material.Classes.Lesson.GroupS.Direction,
                                    Specjalize = x.Material.Classes.Lesson.GroupS.Specjalize,
                                },
                                Teacher = new TeacherDTO()
                                {
                                    Id = x.Material.Classes.Lesson.Teacher.Id,
                                    user = new UserDTO()
                                    {
                                        Id = x.Material.Classes.Lesson.Teacher.Users.Id,
                                        Login = x.Material.Classes.Lesson.Teacher.Users.Login,
                                        ImieNazwisko = x.Material.Classes.Lesson.Teacher.Users.ImieNazwisko,
                                        CzyAktywny = x.Material.Classes.Lesson.Teacher.Users.CzyAktywny,
                                        Password = x.Material.Classes.Lesson.Teacher.Users.Password,
                                        Email = x.Material.Classes.Lesson.Teacher.Users.Email,
                                        Rola = new RolaDTO()
                                        {
                                            Id = x.Material.Classes.Lesson.Teacher.Users.Rola.Id,
                                            Nazwa = x.Material.Classes.Lesson.Teacher.Users.Rola.Nazwa
                                        },
                                        School = new SchoolDTO()
                                        {
                                            Id = x.Material.Classes.Lesson.Teacher.Users.School.Id,
                                            Name = x.Material.Classes.Lesson.Teacher.Users.School.Name,
                                            Logo = x.Material.Classes.Lesson.Teacher.Users.School.Logo
                                        },
                                        NrIndex = x.Material.Classes.Lesson.Teacher.Users.NrIndex,
                                        Image = x.Material.Classes.Lesson.Teacher.Users.Image,
                                        GroupS = new GroupSDTO(),
                                    },
                                    Specjalize = x.Material.Classes.Lesson.Teacher.Specjalize
                                },
                                Subject = new SubjectDTO()
                                {
                                    Id = x.Material.Classes.Lesson.Subject.Id,
                                    Name = x.Material.Classes.Lesson.Subject.Name
                                },
                                TypLesson = x.Material.Classes.Lesson.TypLesson,
                                Time = x.Material.Classes.Lesson.Time
                            },
                            Theme = x.Material.Classes.Theme,
                            DataClasses = x.Material.Classes.DataClasses,
                        },
                        Localization = x.Material.Localization,
                        Name = x.Material.Name,
                        IsActive = x.Material.IsActive,
                        DataActive = x.Material.DataActive
                    },
                    DataDownloading = x.DataDownloading,
                })
            .ToList<HistoryDTO>();
        }

        public IList<HistoryDTO> GetAllWithMaterial(Guid id)
        {
            return NHUnitOfWork.Session.Query<HistoryDownloading>()
                .Where(x=>x.Material.Id == id)
                .Select(x => new HistoryDTO()
                {
                    Id = x.Id,
                    User = new UserDTO()
                    {
                        Id = x.Users.Id,
                        Login = x.Users.Login,
                        ImieNazwisko = x.Users.ImieNazwisko,
                        CzyAktywny = x.Users.CzyAktywny,
                        Password = x.Users.Password,
                        Email = x.Users.Email,
                        Rola = new RolaDTO()
                        {
                            Id = x.Users.Rola.Id,
                            Nazwa = x.Users.Rola.Nazwa
                        },
                        School = new SchoolDTO()
                        {
                            Id = x.Users.School.Id,
                            Name = x.Users.School.Name,
                            Logo = x.Users.School.Logo
                        },
                        NrIndex = x.Users.NrIndex,
                        Image = x.Users.Image,
                        GroupS = new GroupSDTO()
                        {
                            Id = x.Users.GroupS.Id,
                            Year = x.Users.GroupS.Year,
                            Semester = x.Users.GroupS.Semester,
                            Direction = x.Users.GroupS.Direction,
                            Specjalize = x.Users.GroupS.Specjalize,
                        }
                    },
                    Material = new MaterialDTO()
                    {
                        Id = x.Material.Id,
                        Classes = new ClassesDTO()
                        {
                            Id = x.Material.Classes.Id,
                            Lesson = new LessonDTO()
                            {
                                Id = x.Material.Classes.Lesson.Id,
                                GroupS = new GroupSDTO()
                                {
                                    Id = x.Material.Classes.Lesson.GroupS.Id,
                                    Year = x.Material.Classes.Lesson.GroupS.Year,
                                    Semester = x.Material.Classes.Lesson.GroupS.Semester,
                                    Direction = x.Material.Classes.Lesson.GroupS.Direction,
                                    Specjalize = x.Material.Classes.Lesson.GroupS.Specjalize,
                                },
                                Teacher = new TeacherDTO()
                                {
                                    Id = x.Material.Classes.Lesson.Teacher.Id,
                                    user = new UserDTO()
                                    {
                                        Id = x.Material.Classes.Lesson.Teacher.Users.Id,
                                        Login = x.Material.Classes.Lesson.Teacher.Users.Login,
                                        ImieNazwisko = x.Material.Classes.Lesson.Teacher.Users.ImieNazwisko,
                                        CzyAktywny = x.Material.Classes.Lesson.Teacher.Users.CzyAktywny,
                                        Password = x.Material.Classes.Lesson.Teacher.Users.Password,
                                        Email = x.Material.Classes.Lesson.Teacher.Users.Email,
                                        Rola = new RolaDTO()
                                        {
                                            Id = x.Material.Classes.Lesson.Teacher.Users.Rola.Id,
                                            Nazwa = x.Material.Classes.Lesson.Teacher.Users.Rola.Nazwa
                                        },
                                        School = new SchoolDTO()
                                        {
                                            Id = x.Material.Classes.Lesson.Teacher.Users.School.Id,
                                            Name = x.Material.Classes.Lesson.Teacher.Users.School.Name,
                                            Logo = x.Material.Classes.Lesson.Teacher.Users.School.Logo
                                        },
                                        NrIndex = x.Material.Classes.Lesson.Teacher.Users.NrIndex,
                                        Image = x.Material.Classes.Lesson.Teacher.Users.Image,
                                        GroupS = new GroupSDTO(),
                                    },
                                    Specjalize = x.Material.Classes.Lesson.Teacher.Specjalize
                                },
                                Subject = new SubjectDTO()
                                {
                                    Id = x.Material.Classes.Lesson.Subject.Id,
                                    Name = x.Material.Classes.Lesson.Subject.Name
                                },
                                TypLesson = x.Material.Classes.Lesson.TypLesson,
                                Time = x.Material.Classes.Lesson.Time
                            },
                            Theme = x.Material.Classes.Theme,
                            DataClasses = x.Material.Classes.DataClasses,
                        },
                        Localization = x.Material.Localization,
                        Name = x.Material.Name,
                        IsActive = x.Material.IsActive,
                        DataActive = x.Material.DataActive
                    },
                    DataDownloading = x.DataDownloading,
                })
                .OrderBy(x=>x.DataDownloading)
            .ToList<HistoryDTO>();
        }
    }
}
