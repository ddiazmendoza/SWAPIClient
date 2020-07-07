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

            var url = @"https://swapi.dev"; //Sets the base address of rest API 
            var client = new HttpClient() { BaseAddress = new Uri(url) }; // New HttpClient 
            var result = await client.GetAsync($"api/films/{id}/"); // GET verb to the path
            
            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                var film = JsonSerializer.Deserialize<Film>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                film.ShowInfo(client);

            }
            else
            {
                Console.WriteLine("No funciona");
            }

            // client.DefaultRequestHeaders.Add("Authentication", "Bearer HFDHUAISHDIUASHDUISAHDUISHAUDHSAUIDHASIUDHASUIDHIAUHDIUHASUID");
            //...>
        }
        
    }
}
