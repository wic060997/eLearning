using Backend.Auth.Models;
using Model.UserModel.DTO;
using Model.UserModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Auth.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<UserDTO> GetAll();
        Users GetById(Guid id);
        UserDTO GetDTOById(Guid id);
        AuthenticateResponse Registration(RegistrationRequest model);
        void Delete(Guid id);
        void ChangePassword(ChangePasswordDTO model);
        IEnumerable<UserDTO> GetUsersToSchool(Guid id);
        List<UserStudentDTO> GetStudentsFromGroup(Guid id);
        void NewStudent(NewStudentDTO dto);
        StudentDTO GetStudent(Guid id);
    }
}
