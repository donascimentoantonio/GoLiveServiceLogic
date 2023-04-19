using AutoMapper;
using GoLiveServiceLogic_v2.Application.DTO;
using GoLiveServiceLogic_v2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoLiveServiceLogic_v2.Application.Mapping
{
    internal class DtoToDomainMapping : Profile
    {
        public DtoToDomainMapping() {
            CreateMap<UsuarioDto, Usuario>();
            CreateMap<PermissaoDto, Permissao>();
        }
    }
}
