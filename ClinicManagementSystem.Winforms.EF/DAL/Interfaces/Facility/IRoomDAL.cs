using DTO;

namespace DAL.Interfaces.Facility
{
    public interface IRoomDAL : IReadOnlyRepository<RoomDTO, int>, IWriteRepository<RoomDTO>
    {
        Task<bool> Update(RoomDTO room);
        Task<bool> Delete(int id);
    }
}