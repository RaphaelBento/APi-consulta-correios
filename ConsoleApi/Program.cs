using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsoleApi
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("bem vindo ao sistema de consulta de ceps por API");
            Console.WriteLine("Insira o cep que deseja pesquisar  somente numeros sem traço ou ponto!!");
            var cep = Console.ReadLine();
            HttpClient client = new HttpClient { BaseAddress = new Uri("https://viacep.com.br/ws/" + cep + "/json/") };

            var response = await client.GetAsync("");
            var clienteresposta = await response.Content.ReadAsStringAsync();

            var informacaoes = JsonConvert.DeserializeObject<GuardaInfo>(clienteresposta);


            Console.WriteLine($"Bairro:{informacaoes.bairro} \n Cep:{informacaoes.cep}" +
                $"\n DDD:{informacaoes.ddd}" +
                $"\n IBGE: {informacaoes.ibge} \n Localidade:{informacaoes.localidade}" +
                $"\n Logradouro:{informacaoes.logradouro} \n Siafi:{informacaoes.siafi} \n Estado:{informacaoes.uf}");
            Console.ReadLine();
        }
    }
}
