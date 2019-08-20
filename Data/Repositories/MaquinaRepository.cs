using Microsoft.EntityFrameworkCore;
using PontoMarcado.WebApp.Model;
using PontoMarcado.WebApp.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoMarcado.WebApp.Data.Repositories
{
    public interface IMaquinaRepository
    {
        Task<List<Maquina>> GetAll();        
        Task<int> Create(Maquina model);
        Task<Maquina> GetMaquina(string idMaquina);
        Task<int> Edit(Maquina model);
        Task<int> Delete(Maquina model);
    }
    public class MaquinaRepository : IMaquinaRepository
    {
        private readonly ApplicationDbContext _context;

        public MaquinaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(Maquina model)
        {
            _context.Maquina.Add(model);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(Maquina model)
        {
            _context.Maquina.Remove(model);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Edit(Maquina model)
        {
            _context.Update(model);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Maquina>> GetAll()
        {
            return await _context.Maquina.ToListAsync();
        }

        public async Task<Maquina> GetMaquina(string idMaquina)
        {
            return await _context.Maquina.FindAsync(idMaquina);
        }
    }
}
