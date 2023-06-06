using Microsoft.EntityFrameworkCore;
using RSS.Business.Interfaces;
using RSS.Business.Models;
using RSS.Data;
using RSS.Data.Interfaces;
using RSS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSS.Business.DataServices
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _UnitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }
        public List<UserModel> GetAllUsers()
        {
            var allusers = _UnitOfWork.users.GetAll();
            var usersList = allusers.Select(x => new UserModel
            {
                Id = x.Id,
                FullName = x.FullName,
                Number = x.Number,
                Gender = x.Gender,
                CNIC = x.CNIC,
                Email = x.Email,
                Password = x.Password
            }).ToList();
            return usersList;
        }
        public bool Register(UserModel model)
        {
            var email = _UnitOfWork.users.Get(x => x.Email == model.Email).FirstOrDefault();
            if (email == null)
            {
                _UnitOfWork.users.Add(new User
                {
                    Id = model.Id,
                    FullName = model.FullName,
                    Number = model.Number,
                    Gender = model.Gender,
                    CNIC = model.CNIC,
                    Email = model.Email,
                    Password = model.Password
                });
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
                var userList = new UserModel
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Email = user.Email,
                    Gender = user.Gender,
                    Number = user.Number,
                    CNIC = user.CNIC,
                    Password = user.Password
                };
                return userList;
            }
            else
            {
                return null;
            }
        }
    }
}
