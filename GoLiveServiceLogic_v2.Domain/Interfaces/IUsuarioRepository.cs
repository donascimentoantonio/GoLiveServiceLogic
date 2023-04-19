using GoLiveServiceLogic_v2.Domain.Entities;
using GoLiveServiceLogic_v2.Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GoLiveServiceLogic_v2.Domain.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository
    {
        Task<IEnumerable<Usuario>> GetByName(string userName);
        Task<ICollection<Usuario>> GetAllAsync();
        Task<Usuario> GetByIdAsync(int id);
        Task<IQueryable<Usuario>> Query(Expression<Func<Usuario, bool>> Filter);
    }
}
