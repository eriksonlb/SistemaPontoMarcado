using System;
using System.Collections.Generic;
using System.Text;

namespace PontoMarcado.WebApp.Model
{
    public class Maquina
    {
        public string MacAddress { get; set; }
        public string NomeDominio { get; set; }
        public List<RegistroPonto> RegistroPontos { get; set; }
    }
}
