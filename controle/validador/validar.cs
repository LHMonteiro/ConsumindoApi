using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using conApi.controle; 


namespace conApi.controle.validador
{
    public class validar
    {
    private static readonly HttpClient client = new HttpClient();

    public async Task<string> Valida(string nameBusca)
    {
        try
        {
            var resulApi = await VerificarNomes();

            if (resulApi != null)
            {
                foreach (var dateUser in resulApi)
                {
                    if(dateUser.name == nameBusca){
                        return dateUser.name;
                    }
                }
            }
            else
            {
                Console.WriteLine("Não foi possível obter os dados.");
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            
        }

        return null;
    }

    static async Task<User[]> VerificarNomes()
    {
        try
        {
            HttpResponseMessage resposta = await client.GetAsync("https://jsonplaceholder.typicode.com/users").ConfigureAwait(false);

            if (resposta.IsSuccessStatusCode)
            {
                string jsonString = await resposta.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (!string.IsNullOrEmpty(jsonString))
                {
                    User[] users = JsonConvert.DeserializeObject<User[]>(jsonString);
                    return users;
                }
            }

            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao verificar nomes: {ex.Message}");
            return null;
        }
    }
}

    }
