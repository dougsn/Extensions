using AutoMapper;
using Ramal.App.ViewModels;
using Ramal.Business.Models;

namespace Ramal.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Funcionario, FuncionarioViewModel>().ReverseMap();
            CreateMap<Setor, SetorViewModel>().ReverseMap();
        }
    }
}
