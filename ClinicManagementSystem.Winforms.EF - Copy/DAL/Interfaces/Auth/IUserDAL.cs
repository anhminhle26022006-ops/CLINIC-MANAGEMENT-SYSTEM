using System.Collections.Generic;
using DTO;

namespace DAL.Interfaces
{
    public interface IUserDAL
    {
        UserDTO Authenticate(string username, string password);

        List<UserDTO> GetAllUsers();

        bool AddUser(UserDTO user);
    }
}
