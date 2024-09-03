using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public List<Suite> Suite { get; set; }
        public int DiasReservados { get; set; }

        public int ObterQuantidadeHospedes()
        {
            int quantidadeHospedes = 0;

            while (quantidadeHospedes == 0)
            {
                Console.WriteLine("Informe quantas pessoas fazem parte da reserva.\n");
                quantidadeHospedes = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine($"Quantidade de hospedes: {quantidadeHospedes}");

            return quantidadeHospedes;
        }

        public List<Pessoa> CadastrarHospedes(int quantidadeHospedes)
        {
            List<Pessoa> hospedes = new List<Pessoa>();

            for (int i = 1; i <= quantidadeHospedes; i++)
            {
                string nome = "";
                string sobrenome = "";

                while (nome == "")
                {
                    Console.WriteLine("Informe o nome do hóspede.\n");
                    nome = Console.ReadLine();
                }

                while (sobrenome == "")
                {
                    Console.WriteLine("Informe o sobrenome do hóspede.\n");
                    sobrenome = Console.ReadLine();
                }

                Pessoa hospede = new Pessoa(nome, sobrenome);

                hospedes.Add(hospede);
            }

            Console.WriteLine($"Lista de hospedes:");
            Console.WriteLine($"Nome\tSobrenome");
            foreach (Pessoa hospede in hospedes)
            {
                Console.WriteLine($"{hospede.Nome}\t{hospede.Sobrenome}");
            }

            return hospedes;
        }

        public List<(string, decimal)> CadastrarSuite(int numHospedes)
        {
            //TipoSuite
            int tipo;
            string tipoSuite = "";
            int capacidade = 0;
            int hospedesRestantes = numHospedes;
            List<(string suite, decimal diaria)> suites = new List<(string suite, decimal diaria)>();
            decimal valorDiaria = 0.0M;

            while (hospedesRestantes > 0)
            {
                tipo = 0;

                while (tipo != 1 && tipo != 2 && tipo != 3 && tipo != 4)
                {
                    Console.WriteLine($"Informe o tipo de suite ({hospedesRestantes} pessoas).\n1: simples (1 pessoa); \n2: casal (2 pessoas); \n3: família (5 pessoas); \n4: presidencial (10 pessoas).\n");
                    tipo = Convert.ToInt32(Console.ReadLine());
                }

                switch (tipo)
                {
                    case 1:
                        tipoSuite = "Simples";
                        capacidade = 1;
                        valorDiaria = 200.00M;
                        break;
                    case 2:
                        tipoSuite = "Casal";
                        capacidade = 2;
                        valorDiaria = 300.00M;
                        break;
                    case 3:
                        tipoSuite = "Família";
                        capacidade = 5;
                        valorDiaria = 500.00M;
                        break;
                    case 4:
                        tipoSuite = "Presidencial";
                        capacidade = 10;
                        valorDiaria = 1000.00M;
                        break;
                }
                //Capacidade
                //valorDiaria
                Suite suite = new Suite(tipoSuite, capacidade, valorDiaria);
                suites.Add((tipoSuite, valorDiaria));

                hospedesRestantes = hospedesRestantes - capacidade;

                Console.WriteLine($"Hospedes restantes: {hospedesRestantes}");
            }

            Console.WriteLine($"Lista de suites:");
            Console.WriteLine($"Suite\tValor Suite");
            foreach ((string tipo, decimal valorDiaria) suite in suites)
            {
                Console.WriteLine($"{suite.tipo}\t{suite.valorDiaria}");
            }

            return suites;
        }

        public List<(string, decimal, int, decimal)> CalcularValorDiaria(List<(string tipo, decimal valorDiaria)> suites)
        {
            Console.WriteLine("Informe o período da reserva (dias).\n");
            int periodo = Convert.ToInt32(Console.ReadLine());
            decimal valorReserva = 0.0M;
            decimal totalDiarias = 0.0M;

            List<(string tipo, decimal valorDiaria, int periodo, decimal valorTotal)> recibo = new List<(string, decimal, int, decimal)>();

            foreach ((string tipo, decimal valorDiaria) suite in suites)
            {
                // valor total da reserva de uma única suite
                decimal valorSuite = suite.valorDiaria * periodo;
                // valor total de cada diária da reserva
                totalDiarias = totalDiarias + suite.valorDiaria;

                // montagem da tupla com cada suite da reserva
                (string tipo, decimal valorDiaria, int periodo, decimal valorTotal) subRecibo = (suite.tipo, suite.valorDiaria, periodo, valorSuite);

                // adiciona suite ao recibo
                recibo.Add(subRecibo);

                // calculo do valor total da reserva
                valorReserva = valorReserva + subRecibo.valorTotal;
            }

            // montagem da tupla com total da reserva
            (string tipo, decimal valorDiaria, int periodo, decimal valorTotal) totalRecibo = ("Total", totalDiarias, periodo, valorReserva);
            // adiciona tupla com total ao recibo
            recibo.Add(totalRecibo);

            Console.WriteLine($"Suite\tValor Suite\tPeriodo\tTotal Suite");
            foreach ((string tipo, decimal valorDiaria, int periodo, decimal valorTotal) registro in recibo)
            {
                Console.WriteLine($"{registro.tipo}\t{registro.valorDiaria}\t\t{registro.periodo}\t{registro.valorTotal}");
            }

            return recibo;
        }
    }
}