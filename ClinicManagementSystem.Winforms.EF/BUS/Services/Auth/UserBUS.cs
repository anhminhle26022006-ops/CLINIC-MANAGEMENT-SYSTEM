using System;
using System.Collections.Generic;
using DAL.Repositories;
using DTO;

namespace BUS.Services
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

        public List<UserDTO> GetAllUsers()
        {
            return dal.GetAllUsers();
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

        public bool UpdateUser(UserDTO user)
        {
            if (user == null || user.UserID <= 0)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(user.Name) || string.IsNullOrWhiteSpace(user.Password) || string.IsNullOrWhiteSpace(user.Role))
            {
                return false;
            }

            return dal.UpdateUser(user);
        }

        public bool SetActive(int userId, bool isActive)
        {
            return userId > 0 && dal.SetActive(userId, isActive);
        }
    }
}

