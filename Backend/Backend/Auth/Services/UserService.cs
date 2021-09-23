using Backend.Auth.Helpers;
using Backend.Auth.Models;
using Infrastructure;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Model.SchoolModel.Entity;
using Model.SchoolModel.IService;
using Model.UserModel.DTO;
using Model.UserModel.Entity;
using Model.UserModel.IService;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Auth.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private Model.UserModel.IService.IUserService useresService;
        private IRolaService roleService;
        private ISchoolService schoolService;

        public UserService(
            IOptions<AppSettings> appSettings, 
            Model.UserModel.IService.IUserService useresService,
            IRolaService roleService,
            ISchoolService schoolService
            )
        {
            _appSettings = appSettings.Value;
            this.useresService = useresService;
            this.roleService = roleService;
            this.schoolService = schoolService;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            IList<UserDTO> _users = useresService.getAllDTO();

            var user = _users.SingleOrDefault(x => x.Login == model.login && x.Password == model.password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public void ChangePassword(ChangePasswordDTO model)
        {
            useresService.ChangePassword(model.Id, model.OldPassword, model.Password, model.Password);
        }

        public void Delete(Guid id)
        {
            useresService.UsunUzytkownika(id);
        }

        public IEnumerable<UserDTO> GetAll()
        {
            return useresService.getAllDTO();
        }

        public Users GetById(Guid id)
        {
            return useresService.getAll().FirstOrDefault(x => x.Id == id);
        }

        public UserDTO GetDTOById(Guid id)
        {
            return useresService.getAllDTO().FirstOrDefault(x => x.Id == id);
        }

        public StudentDTO GetStudent(Guid id)
        {
            return useresService.GetStudent(id);
        }

        public List<UserStudentDTO> GetStudentsFromGroup(Guid id)
        {
            return useresService.GetStudentsFromGroup(id);
        }

        public IEnumerable<UserDTO> GetUsersToSchool(Guid id)
        {
            return useresService.getUserSchool(id);
        }

        public void NewStudent(NewStudentDTO dto)
        {
           useresService.NewStudent(dto);
        }

        public AuthenticateResponse Registration(RegistrationRequest model)
        {
            IList<Rola> re = roleService.GetAll();
            Rola r = re.FirstOrDefault(x => x.Nazwa == "BRAK");

            School school = schoolService.GetSchool(model.school);
            Random rnd = new Random();

            Users user = new Users(Guid.NewGuid(), model.login, model.password,model.imieNazwisko,true, model.email,r, new AuditData("system", DateTime.Now), null, school,rnd.Next(1,999999), null);

            user.Validate();

            Guid id = useresService.AddUser(user);

            UserDTO dto = useresService.PobierzUzytkownika(id);
            var token = generateJwtToken(dto);

            return new AuthenticateResponse(dto, token);
        }

        
        private string generateJwtToken(UserDTO user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
