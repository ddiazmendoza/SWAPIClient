using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SwapiClient
{
    class Program
    {
        async static Task Main(string[] args) 
        {
            string id = args.Length == 0 ? "1" : args[0];

            var url = "https://swapi.dev/";
            var client = new HttpClient() {BaseAddress = new Uri(url)};
            var response = await client.GetAsync($"api/films/{id}"); // Respuesta

            if (response.IsSuccessStatusCode) 
            {
                var content = await response.Content.ReadAsStringAsync(); // Contenido de la respuesta
                var film = JsonSerializer.Deserialize<Film>
                    (content, new JsonSerializerOptions() 
                        {PropertyNameCaseInsensitive = true});
                        film.ShowInfo();
            }
            else 
            {
                System.Console.WriteLine("Client not working");
            }

        }
    }
}
