using GoLiveServiceLogic_v2.Domain.Interfaces.Base;
using GoLiveServiceLogic_v2.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GoLiveServiceLogic_v2.Infra.Data.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        private readonly AppDbContext _appDbContext;

        public BaseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void CreateAsync<T>(T entity) where T : class
        {
            _appDbContext.Add<T>(entity);
        }

        public void DeleteAsync<T>(T entity) where T : class
        {

             _appDbContext.Set<T>().Remove(entity);
        }

        public void EditAsync<T>(T entity) where T : class
        {
            _appDbContext.Set<T>().Update(entity);
        }

        public async Task<bool> SaveChanges()
        {
            try
            {
                _appDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
