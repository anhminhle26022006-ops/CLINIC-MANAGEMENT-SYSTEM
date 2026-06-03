using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Models;

namespace DAL.Interfaces
{
    public interface IRepository<T>
    {
        List<T> GetAll();

        T? GetById(Guid id);

        bool Add(T entity);

        bool Update(T entity);

        bool Delete(Guid id);
    }
}
