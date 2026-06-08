using System;
using DAL.Repositories;
using DTO;

namespace BUS.Services
{
    public class UserBUS
    {
        private readonly UserDAL _dal = new UserDAL();

        public UserDTO Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentException("Tên đăng nhập không được để trống.");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Mật khẩu không được để trống.");
            return _dal.Authenticate(username.Trim(), password);
        }

        public bool CreateUser(UserDTO user)
        {
            if (user == null) return false;
            if (string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.Password) || string.IsNullOrWhiteSpace(user.Name))
                return false;
            return _dal.AddUser(user);
        }

        public void UpdateUser(int userId, string email, string newPassword = null)
        {
            if (userId <= 0) throw new ArgumentException("UserID không hợp lệ.");
            _dal.UpdateUser(userId, email, newPassword);
        }

        public void SetUserActive(int userId, bool isActive)
        {
            if (userId <= 0) throw new ArgumentException("UserID không hợp lệ.");
            _dal.SetUserActive(userId, isActive);
        }
    }
}