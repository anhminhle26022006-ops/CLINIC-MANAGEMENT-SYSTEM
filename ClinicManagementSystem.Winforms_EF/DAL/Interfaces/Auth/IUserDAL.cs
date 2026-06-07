using DTO;

namespace DAL.Interfaces
{
    public interface IUserDAL
    {
        UserDTO Authenticate(string username, string password);

        bool AddUser(UserDTO user);
    }
}
