using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PontoMarcado.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoMarcado.WebApp.Data.Repositories
{
    public interface IApplicationUserRepository
    {
        Task<List<IdentityUser>> GetUsuarios();
    }
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<IdentityUser>> GetUsuarios()
        {
            return await _context.Users
                .ToListAsync();
        }
    }
}
