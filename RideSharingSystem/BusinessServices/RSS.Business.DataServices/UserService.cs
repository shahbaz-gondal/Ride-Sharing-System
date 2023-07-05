using AutoMapper;
using RSS.Business.Interfaces;
using RSS.Business.Models;
using RSS.Data.Interfaces;
using RSS.Data.Models;

namespace RSS.Business.DataServices
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _UnitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public List<UserModel> GetAllUsers()
        {
            var allusers = _UnitOfWork.users.GetAll();
            var usersList = _mapper.Map<List<UserModel>>(allusers);
            return usersList;
        }
        public bool Register(UserModel model)
        {
            var email = _UnitOfWork.users.Get(x => x.Email == model.Email).FirstOrDefault();
            if (email == null)
            {
                var entity = _mapper.Map<User>(model);
                _UnitOfWork.users.Add(entity);
                _UnitOfWork.Save();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool FindEmail(string Email, string CNIC)
        {
            var email = _UnitOfWork.users.Get(x => x.Email == Email && x.CNIC == CNIC).FirstOrDefault();
            if(email == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void ResetPassword(UserModel model)
        {
            var entity = _UnitOfWork.users.Get(x => x.Email == model.Email).FirstOrDefault();
            if (entity != null)
            {
                entity.Password = model.Password;
            }
            _UnitOfWork.Save();
        }
        public UserModel Login(UserModel model)
        {
            var user = _UnitOfWork.users.Get(x => x.Email == model.Email && x.Password == model.Password).FirstOrDefault();
            
            if (user != null)
            {
                var userList = _mapper.Map<UserModel>(user);
                return userList;
            }
            else
            {
                return null;
            }
        }
    }
}
