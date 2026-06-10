namespace DAL.Interfaces
{
    public interface IWriteRepository<TDto>
    {
        Task<bool> Add(TDto dto);
        Task<bool> Update(TDto dto);
        Task<bool> Delete(object id);

    }

}