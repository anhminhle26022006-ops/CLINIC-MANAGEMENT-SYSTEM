using System;
using BUS.Interfaces;
using DAL.Interfaces;
using DAL.Repositories;
using DTO;

namespace BUS.Services
{
    public class UserBUS : IUserBUS
    {
        private readonly IUserDAL _userDAL;

        public UserBUS()
        {
            _userDAL = new UserDAL();
        }

        public UserDTO Login(
            string username,
            string password)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException(
                    "Tên đăng nhập không được để trống.");

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException(
                    "Mật khẩu không được để trống.");

            return _userDAL.Authenticate(
                username.Trim(),
                password);
        }

        public bool CreateUser(UserDTO user)
        {
            if (user == null)
                return false;

            if (string.IsNullOrWhiteSpace(user.Username))
                return false;

            if (string.IsNullOrWhiteSpace(user.PasswordHash))
                return false;

            if (user.RoleID <= 0)
                return false;

            return _userDAL.AddUser(user);
        }
    }
}