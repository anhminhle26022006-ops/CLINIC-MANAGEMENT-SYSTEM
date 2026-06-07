namespace DAL.Interfaces
{
    public interface IWriteRepository<TDto>
    {
        bool Add(TDto dto);
    }
}
