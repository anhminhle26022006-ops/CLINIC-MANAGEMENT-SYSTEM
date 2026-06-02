using System;
using MOMO_QR_DANANG.DataAccess;
using MOMO_QR_DANANG.Models;

namespace MOMO_QR_DANANG.Business
{
    public class UserBUS
    {
        private readonly UserDAL dal = new UserDAL();

        public UserDTO Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Tên đăng nhập không được để trống.");
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Mật khẩu không được để trống.");
            }

            return dal.Authenticate(username.Trim(), password);
        }

        public bool CreateUser(UserDTO user)
        {
            if (user == null) return false;
            if (string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.Password) || string.IsNullOrWhiteSpace(user.Name))
            {
                return false;
            }
            return dal.AddUser(user);
        }
    }
}

