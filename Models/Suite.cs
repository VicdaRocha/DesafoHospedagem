using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioHospedagem.Models
{
    public class Suite
    {
        public Suite(string tipoSuite, int capacidade, decimal valorDiaria)
        {
            this.TipoSuite = tipoSuite;
            this.Capacidade = capacidade;
            this.ValorDiaria = valorDiaria;
        }
        public string TipoSuite { get; set; } // 1: simples; 2: casal; 3: família; 4: presidencial.
        public int Capacidade { get; set; }
        public decimal ValorDiaria { get; set; }
    }
}