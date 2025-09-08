using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = (Console.ReadLine() ?? "").Trim().ToUpper();

            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("Placa inválida. Operação cancelada.");
                return;
            }

            if (veiculos.Any(x => x.Equals(placa, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Esse veículo já está cadastrado.");
                return;
            }

            veiculos.Add(placa);
            Console.WriteLine("Veículo cadastrado com sucesso!");
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = (Console.ReadLine() ?? "").Trim().ToUpper();

            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("Placa inválida. Operação cancelada.");
                return;
            }

            if (veiculos.Any(x => x.Equals(placa, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                if (!int.TryParse(Console.ReadLine(), out int horas) || horas < 0)
                {
                    Console.WriteLine("Quantidade de horas inválida. Operação cancelada.");
                    return;
                }

                decimal valorTotal = precoInicial + (precoPorHora * horas);

                veiculos.RemoveAll(x => x.Equals(placa, StringComparison.OrdinalIgnoreCase));
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal:N2}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                int i = 1;
                foreach (var v in veiculos)
                {
                    Console.WriteLine($"{i++}. {v}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
