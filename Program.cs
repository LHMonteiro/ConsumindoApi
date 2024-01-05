using System;
using System.Net.Http;
using System.Threading.Tasks;
using conApi.controle;
using conApi.controle.validador;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            var validador = new conApi.controle.validador.validar();
            Console.WriteLine("Digite um nome para buscar no banco de dados: ");
            string nomePesquisa = Console.ReadLine();

            var resultado = await validador.Valida(nomePesquisa);

            if (resultado != null)
            {
                Console.WriteLine($"Usuário encontrado: {resultado}");
            }
            else
            {
                Console.WriteLine("Usuário não encontrado ou ocorreu um erro.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro: {ex.Message}");
        }
    }
} 

// Restante do código...
