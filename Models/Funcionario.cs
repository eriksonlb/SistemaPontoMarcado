using Microsoft.AspNetCore.Identity;
using PontoMarcado.WebApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PontoMarcado.WebApp.Model
{
    public class Funcionario
    {
        public int Id { get; set; }

        public string NomeFuncionario { get; set; }
        public IdentityUser Usuario { get; set; }

        public string UserId { get; set; }

        public decimal SalarioBase { get; set; }

    }
}
