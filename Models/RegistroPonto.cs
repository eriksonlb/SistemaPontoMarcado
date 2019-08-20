using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PontoMarcado.WebApp.Model
{
    public class RegistroPonto
    {
        public int Id { get; set; }        
        public string NomeUsuario { get; set; }        
        public Maquina Maquina { get; set; }
        public DateTime HorarioRegistro { get; set; }
        public string AlteracaoSessao { get; set; }
    }
}
