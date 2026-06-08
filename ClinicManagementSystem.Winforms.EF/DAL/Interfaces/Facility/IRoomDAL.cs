using DTO;

namespace DAL.Interfaces
{
    public interface IRoomDAL : IReadOnlyRepository<RoomDTO, int>
    {
    }
}
