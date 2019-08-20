using Microsoft.EntityFrameworkCore;
using PontoMarcado.WebApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoMarcado.WebApp.Data.Repositories
{
    public interface IRegistroPontoRepository
    {
        Task<List<RegistroPonto>> GetAll();
        Task<List<RegistroPonto>> GetRegistrosPorDominio(string dominio);
    }
    public class RegistroPontoRepository : IRegistroPontoRepository
    {
        private readonly ApplicationDbContext _context;

        public RegistroPontoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<RegistroPonto>> GetAll()
        {
            return await _context.RegistroPonto.ToListAsync();
        }

        public async Task<List<RegistroPonto>> GetRegistrosPorDominio(string dominio)
        {
            var macAddress = _context.Maquina.Where(x => x.NomeDominio == dominio).FirstOrDefault().MacAddress;

            return await _context.RegistroPonto
                .Where(x => x.Maquina.MacAddress == macAddress)
                .ToListAsync();
        }
    }
}
