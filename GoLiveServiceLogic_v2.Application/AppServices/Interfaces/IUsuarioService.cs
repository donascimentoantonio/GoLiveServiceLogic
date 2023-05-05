using GoLiveServiceLogic_v2.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoLiveServiceLogic_v2.Application.AppServices.Interfaces
{
    public interface IUsuarioService
    {
        Task<ResultService<UsuarioDto>> CreateAsync(UsuarioDto usuarioDto);
        Task<ResultService> DeleteAsync(int id);
        Task<ResultService<ICollection<UsuarioDto>>> GetAllAsync();
        Task<ResultService<UsuarioDto>> GetByIdAsync(int id);
        Task<ResultService> PutAsync(UsuarioDto usuarioDto);
    }
}
