using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PontoMarcado.WebApp.Model;
using PontoMarcado.WebApp.Models;

namespace PontoMarcado.WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<RegistroPonto> RegistroPonto { get; set; }
        public DbSet<Maquina> Maquina { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Maquina>()
                .HasKey(maq => maq.MacAddress);

            builder.Entity<Funcionario>()
                .HasKey(x => x.Id);

            
        }
    }
}
