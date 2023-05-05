using AutoMapper;
using AutoMapper.Configuration;
using GoLiveServiceLogic_v2.Application.AppServices.Interfaces;
using GoLiveServiceLogic_v2.Application.DTO;
using GoLiveServiceLogic_v2.Application.DTO.Validations;
using GoLiveServiceLogic_v2.Domain.Entities;
using GoLiveServiceLogic_v2.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoLiveServiceLogic_v2.Application.AppServices
{
    public class UsuarioService : IUsuarioService
    {
        //O uso do padrão Services é para abstrair qualquer programação da camada de controller

        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<UsuarioDto>> CreateAsync(UsuarioDto usuarioDto)
        {
            if (usuarioDto == null)
                return ResultService.Fail<UsuarioDto>("O usuário não foi informado");

            //Aplica as validações dos dados vindos do controler
            var result = new UsuarioDtoValidator().Validate(usuarioDto);
            if (!result.IsValid)
                return ResultService.RequestError<UsuarioDto>("As informações colocadas no usuário não são válidas.", result);

            //aplica a conversão do objeto mais externo para o mais interno (Controller x Banco)
            var usuario = _mapper.Map<Usuario>(usuarioDto);

            //Faz interação com o banco de dados

            _usuarioRepository.CreateAsync(usuario);
            await _usuarioRepository.SaveChanges();

            return ResultService.Ok<UsuarioDto>(_mapper.Map<UsuarioDto>(usuario));
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var usuarioBanco = await _usuarioRepository.GetByIdAsync(id);
            if (usuarioBanco == null)
            {
                return ResultService.Fail("Usuário não encontrado!");
            }

             _usuarioRepository.DeleteAsync(usuarioBanco);
            await _usuarioRepository.SaveChanges();

            return ResultService.Ok($"Usuário {usuarioBanco.Name} id: {id} excluído com sucesso");

        }

        public async Task<ResultService<ICollection<UsuarioDto>>> GetAllAsync()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();
            if (!usuarios.Any())
                return ResultService.Fail<ICollection<UsuarioDto>>("Nenhum usuário encontrado");
            else
                return ResultService.Ok(_mapper.Map<ICollection<UsuarioDto>>(usuarios));
        }

        public async Task<ResultService<UsuarioDto>> GetByIdAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);

            if (usuario == null)
                return ResultService.Fail<UsuarioDto>("Usuário não encontradoo");

            return ResultService.Ok(_mapper.Map<UsuarioDto>(usuario));
        }

        public async Task<ResultService> PutAsync(UsuarioDto usuarioDto)
        {
            if (usuarioDto == null)
                ResultService.Fail("Usuário deve ser informado");

            var result = new UsuarioDtoValidator().Validate(usuarioDto);
            if (!result.IsValid)
                return ResultService.RequestError("As informações colocadas no usuário não são válidas.", result);

            var usuario = await _usuarioRepository.GetByIdAsync(usuarioDto.Id);
            if (usuario == null)
                return ResultService.Fail("Usuário não encontrado");

            usuario = _mapper.Map(usuarioDto, usuario);

             _usuarioRepository.EditAsync(usuario);

            await _usuarioRepository.SaveChanges();

            return ResultService.Ok("Usuário atualizado com sucesso");
        }
    }
}
