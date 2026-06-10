namespace DAL.Interfaces
{
    public interface IReadOnlyRepository<TDto, TKey>
    {
        Task<List<TDto>> GetAll();
        Task<TDto> GetById(TKey id);
        Task<bool> Exists(TKey id);
    }
}