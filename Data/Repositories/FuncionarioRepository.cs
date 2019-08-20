using Microsoft.EntityFrameworkCore;
using PontoMarcado.WebApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoMarcado.WebApp.Data.Repositories
{
    public interface IFuncionarioRepository
    {
        Task<List<Funcionario>> GetAll();
        Task<int> Create(Funcionario model);
        Task<Funcionario> GetFuncionario(int id);
        Task<int> Edit(Funcionario model);
        Task<int> Delete(Funcionario model);
    }
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly ApplicationDbContext _context;

        public FuncionarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(Funcionario model)
        {
            _context.Funcionario.Add(model);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(Funcionario model)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Edit(Funcionario model)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Funcionario>> GetAll()
        {
            //TODO - Não está pegando as informacoes do usuario
            var funcionarios = await _context.Funcionario                 
                .ToListAsync();

            foreach (var funcionario in funcionarios)
            {
                funcionario.Usuario = await _context.Users
                    .Where(x => x.Id == funcionario.UserId)
                    .SingleOrDefaultAsync();
            }

            return funcionarios;
        }

        public async Task<Funcionario> GetFuncionario(int id)
        {
            return await _context.Funcionario
                .Include(f => f.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
