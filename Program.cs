using System.Globalization;
using DesafioFundamentos.Models;

// Encoding para acentuação no console
Console.OutputEncoding = System.Text.Encoding.UTF8;

// Função utilitária para ler decimal com validação
decimal LerDecimal(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        var entrada = Console.ReadLine();

        if (decimal.TryParse(
                entrada,
                NumberStyles.Number,
                CultureInfo.CurrentCulture,
                out var valor))
        {
            return valor;
        }

        Console.WriteLine("Valor inválido. Tente novamente.");
    }
}

Console.WriteLine("Seja bem-vindo ao sistema de estacionamento!");
var precoInicial = LerDecimal("Digite o preço inicial: ");
var precoPorHora = LerDecimal("Agora digite o preço por hora: ");

// Instancia a classe Estacionamento, já com os valores
var es = new Estacionamento(precoInicial, precoPorHora);

bool exibirMenu = true;
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar (ou 'q')");

    var escolha = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();

    switch (escolha)
    {
        case "1":
            es.AdicionarVeiculo();
            break;

        case "2":
            es.RemoverVeiculo();
            break;

        case "3":
            es.ListarVeiculos();
            break;

        case "4":
        case "q":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida.");
            break;
    }

    if (exibirMenu)
    {
        Console.WriteLine("\nPressione Enter para continuar...");
        Console.ReadLine();
    }
}

Console.WriteLine("O programa se encerrou.");
