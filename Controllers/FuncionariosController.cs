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
using PontoMarcado.WebApp.Models.ViewModels;

namespace PontoMarcado.WebApp.Controllers
{
    [Authorize]
    public class FuncionariosController : Controller
    {
        private IFuncionarioRepository _funcRepository;
        private IApplicationUserRepository _userRepository;
        private IMapper _mapper;

        public FuncionariosController(IFuncionarioRepository funcRepository, IMapper mapper
            , IApplicationUserRepository userRepository)
        {
            _funcRepository = funcRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        // GET: Funcionarios
        public async Task<IActionResult> Index()
        {
            var funcionarios = _mapper.Map<List<FuncionarioViewModel>>(await _funcRepository.GetAll());            
            return View(funcionarios);
        }

        // GET: Funcionarios/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var funcionario = _mapper.Map<FuncionarioViewModel>(await _funcRepository.GetFuncionario(id));
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // GET: Funcionarios/Create
        public async Task<IActionResult> Create()
        {               
            ViewData["UserId"] = new SelectList(await _userRepository.GetUsuarios(), "Id", "Email");
            return View();
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeFuncionario,UserId,SalarioBase")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                await _funcRepository.Create(funcionario);
                return RedirectToAction(nameof(Index));
            }
            //ViewData["UserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", funcionario.UserId);
            return View(funcionario);
        }

        // GET: Funcionarios/Edit/5
        public async Task<IActionResult> Edit(int id)
        {           
            var funcionario = await _funcRepository.GetFuncionario(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            //ViewData["UserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", funcionario.UserId);
            return View(funcionario);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeFuncionario,UserId,SalarioBase")] Funcionario funcionario)
        {
            if (id != funcionario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(funcionario);
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!FuncionarioExists(funcionario.Id))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["UserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", funcionario.UserId);
            return View(funcionario);
        }

        // GET: Funcionarios/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var funcionario = await _funcRepository.GetFuncionario(id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var funcionario = await _context.Funcionario.FindAsync(id);
            //_context.Funcionario.Remove(funcionario);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //private bool FuncionarioExists(int id)
        //{
        //    return _context.Funcionario.Any(e => e.Id == id);
        //}
    }
}
