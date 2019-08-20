using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PontoMarcado.WebApp.Models.ViewModels
{
    public class FuncionarioViewModel
    {
        public int Id { get; set; }
        [DisplayName("Nome do Funcionário")]
        public string NomeFuncionario { get; set; }        
        [DisplayName("Salario Base")]
        public decimal SalarioBase { get; set; }
        [DisplayName("Email do Usuário")]
        public IdentityUser Usuario { get; set; }
        //public List<IdentityUser> Usuarios { get; set; }

    }
}
