using System.Collections.Generic;
using DTO;

namespace BUS.Interfaces
{
    public interface IUserBUS
    {
        UserDTO Login(string username, string password);

        List<UserDTO> GetAllUsers();

        bool CreateUser(UserDTO user);
    }
}
