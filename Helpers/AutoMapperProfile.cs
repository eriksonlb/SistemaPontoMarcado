using AutoMapper;
using PontoMarcado.WebApp.Model;
using PontoMarcado.WebApp.Models;
using PontoMarcado.WebApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoMarcado.WebApp.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Maquina, MaquinaViewModel>();
            CreateMap<MaquinaViewModel, Maquina>();

            CreateMap<RegistroPonto, RegistroPontoViewModel>();
            CreateMap<RegistroPontoViewModel, RegistroPonto>();

            CreateMap<Funcionario, FuncionarioViewModel>();
            CreateMap<FuncionarioViewModel, Funcionario>();

            CreateMap<ApplicationUser, ApplicationUser>();
        }
    }
}
