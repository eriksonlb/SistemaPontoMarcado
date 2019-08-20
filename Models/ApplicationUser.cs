using Microsoft.AspNetCore.Identity;
using PontoMarcado.WebApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoMarcado.WebApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public Funcionario Funcionario { get; set; }
    }
}
