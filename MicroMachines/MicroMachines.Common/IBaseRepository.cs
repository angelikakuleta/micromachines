using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MicroMachines.Common
{
    public interface IBaseRepository<T> where T : Entity
    {
        Task<IList<T>> GetAll();
        Task<T> GetSingle(Expression<Func<T, bool>> condition);
        Task<T> Add(T entity);
        Task<T> Edit(T entity);
        Task Delete(T entity);
    }
}
