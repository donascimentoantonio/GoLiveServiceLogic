using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoLiveServiceLogic_v2.Domain
{
    public interface IBaseRepository
    {
        public void CreateAsync<T>(T entity) where T : class;
        public void EditAsync<T>(T entity) where T : class;
        public void DeleteAsync<T>(T entity) where T : class;
        public Task<bool> SaveChanges();
    }
}
