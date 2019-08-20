using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PontoMarcado.WebApp.Data;
using PontoMarcado.WebApp.Data.Repositories;
using PontoMarcado.WebApp.Model;
using PontoMarcado.WebApp.Models;

namespace PontoMarcado.WebApp.Controllers
{
    [Authorize]
    public class MaquinasController : Controller
    {
        private IMaquinaRepository _repository;
        private IMapper _mapper;

        public MaquinasController(IMaquinaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: Maquinas
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<List<MaquinaViewModel>>(await _repository.GetAll()));
            //return View(await _context.Maquina.ToListAsync());
        }

        // GET: Maquinas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var maquina = await _context.Maquina
            //    .FirstOrDefaultAsync(m => m.MacAddress == id);
            var maquina = _mapper.Map<MaquinaViewModel>(await _repository.GetMaquina(id));
            if (maquina == null)
            {
                return NotFound();
            }

            return View(maquina);
        }

        // GET: Maquinas/Create
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MacAddress,NomeDominio")] MaquinaViewModel maquina)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(maquina);
                //await _context.SaveChangesAsync();
                var retorno = await _repository.Create(_mapper.Map<Maquina>(maquina));
                if(retorno > 0)
                    return RedirectToAction(nameof(Index));
            }
            return View(maquina);
        }

        // GET: Maquinas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var maquina = await _context.Maquina.FindAsync(id);
            var maquina = _mapper.Map<MaquinaViewModel>(await _repository.GetMaquina(id));
            if (maquina == null)
            {
                return NotFound();
            }
            return View(maquina);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MacAddress,NomeDominio")] Maquina maquina)
        {
            if (id != maquina.MacAddress)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {                
                var retorno = await _repository.Edit(_mapper.Map<Maquina>(maquina));

                if(retorno > 0)
                    return RedirectToAction(nameof(Index));
            }
            return View(maquina);
        }

        // GET: Maquinas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var maquina = await _context.Maquina
            //    .FirstOrDefaultAsync(m => m.MacAddress == id);
            var maquina = _mapper.Map<MaquinaViewModel>(await _repository.GetMaquina(id));
            if (maquina == null)
            {
                return NotFound();
            }

            return View(maquina);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {            
            var maquina = await _repository.GetMaquina(id);
            await _repository.Delete(maquina);
            return RedirectToAction(nameof(Index));
        }

    }
}
