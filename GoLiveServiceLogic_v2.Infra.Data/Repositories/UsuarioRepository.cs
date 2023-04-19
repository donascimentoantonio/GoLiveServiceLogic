using GoLiveServiceLogic_v2.Domain;
using GoLiveServiceLogic_v2.Domain.Entities;
using GoLiveServiceLogic_v2.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GoLiveServiceLogic_v2.Infra.Data.Repositories
{
    public class UsuarioRepository : BaseRepository, IUsuarioRepository, IRepository<Usuario>
    {
        private readonly AppDbContext _appDbContext;

        //Sobrescreve o objeto de conexão com banco da classe genérica
        public UsuarioRepository(AppDbContext appDbContext) : base(appDbContext) => _appDbContext = appDbContext;

        public async Task<ICollection<Usuario>> GetAllAsync()
        {
            return await _appDbContext.Usuarios.ToListAsync();
        }
        public async Task<Usuario> GetByIdAsync(int id) => await _appDbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Usuario>> GetByName(string userName)
        {
            return await _appDbContext.Usuarios.Where(x => x.Name == userName).ToListAsync();
        }

        public async Task<IQueryable<Usuario>> Query(Expression<Func<Usuario, bool>> filter)
        {
            var usuarios = await _appDbContext.Usuarios.Where(filter).ToListAsync();
            return usuarios.AsQueryable();
        }

        //Lembre-se sempre de adicionar a referencia do repositorio na classe ServiceColletion na Program.cs ou melhor na camada de IoC
    }
}
