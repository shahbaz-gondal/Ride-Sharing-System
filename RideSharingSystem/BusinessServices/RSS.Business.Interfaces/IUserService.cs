using RSS.Business.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSS.Business.Interfaces
{
    public interface IUserService
    {
        public bool Register(UserModel model);
        public List<UserModel> GetAllUsers();
        public bool FindEmail(string Email, string CNIC);
        public void ResetPassword(UserModel model);
        public  UserModel Login(UserModel model);
    }
}
