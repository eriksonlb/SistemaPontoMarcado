using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PontoMarcado.WebApp.Models
{
    public class RegistroPontoViewModel
    {
        public int Id { get; set; }
        [DisplayName("Nome Usuário")]
        public string NomeUsuario { get; set; }        
        public MaquinaViewModel Maquina { get; set; }
        [DisplayName("Horário Registro")]
        public DateTime HorarioRegistro { get; set; }
        [DisplayName("Alteração da Sessão")]
        public string AlteracaoSessao { get; set; }
    }
}
