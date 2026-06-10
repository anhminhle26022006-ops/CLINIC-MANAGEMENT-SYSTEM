using DAL.DataContext;
using DAL.Models;
using DAL.Repositories;
using DTO;
using System;
using System.Collections.Generic;

namespace BUS.Services
{
    public class UserBUS
    {
        private readonly UserDAL _dal;

        // Constructor nhận CMSDbContext
        public UserBUS(CMSDbContext context)
        {
            _dal = new UserDAL(context);
        }

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

            return _dal.Authenticate(username.Trim(), password);
        }

        public List<UserDTO> GetAllUsers()
        {
            return _dal.GetAllUsers();
        }

        public bool CreateUser(UserDTO user)
        {
            if (user == null) return false;
            if (string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.Password) || string.IsNullOrWhiteSpace(user.Name))
            {
                return false;
            }
            return _dal.AddUser(user);
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

            return _dal.UpdateUser(user);
        }

        public bool SetActive(int userId, bool isActive)
        {
            return userId > 0 && _dal.SetActive(userId, isActive);
        }
    }
}