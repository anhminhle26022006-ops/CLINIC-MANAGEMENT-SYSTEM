using System.Collections.Generic;

namespace BUS.Interfaces
{
    public interface IReadOnlyService<TDto, TKey>
    {
        List<TDto> GetAll();
        TDto GetById(TKey id);
        bool Exists(TKey id);
    }
}
