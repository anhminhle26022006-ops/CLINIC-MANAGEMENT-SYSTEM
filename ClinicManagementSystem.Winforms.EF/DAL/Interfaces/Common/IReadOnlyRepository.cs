using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IReadOnlyRepository<TDto, TKey>
    {
        List<TDto> GetAll();
        TDto GetById(TKey id);
        bool Exists(TKey id);
    }
}
