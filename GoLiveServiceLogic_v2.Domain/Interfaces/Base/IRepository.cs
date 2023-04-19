using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GoLiveServiceLogic_v2.Domain.Interfaces.Base
{
    public interface IRepository<T>
    {
        Task<T> GetByIdAsync(int id);
        Task<ICollection<T>> GetAllAsync();
        Task<IQueryable<T>> Query(Expression<Func<T, bool>> Filter);
    }
}
