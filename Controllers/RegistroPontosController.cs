using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PontoMarcado.WebApp.Data;
using PontoMarcado.WebApp.Data.Repositories;
using PontoMarcado.WebApp.Models;


namespace PontoMarcado.WebApp.Controllers
{
    public class RegistroPontosController : Controller
    {
        private readonly IRegistroPontoRepository _repository;
        private IMapper _mapper;

        public RegistroPontosController(IRegistroPontoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: RegistroPontos
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<List<RegistroPontoViewModel>>(await _repository.GetAll()));
        }

        public async Task<IActionResult> BuscaPorDominio(string dominio)
        {
            var registroPonto = _mapper.Map<List<RegistroPontoViewModel>>(await _repository.GetRegistrosPorDominio(dominio));
            return RedirectToAction(nameof(Index), registroPonto);
        }

    }
}
