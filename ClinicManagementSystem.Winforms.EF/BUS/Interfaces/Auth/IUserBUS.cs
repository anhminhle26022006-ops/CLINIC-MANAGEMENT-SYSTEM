using DTO;

namespace BUS.Interfaces
{
    public interface IUserBUS
    {
        UserDTO Login(string username, string password);

        bool CreateUser(UserDTO user);
    }
}
