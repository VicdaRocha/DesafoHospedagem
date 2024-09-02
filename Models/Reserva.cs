using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public void CadastrarHospedes()
        {

        }

        public void CadastrarSuite()
        {

        }

        public int ObterQuantidadeHospedes()
        {

            return;
        }

        public decimal CalcularValorDiaria()
        {

            return;
        }
    }
}