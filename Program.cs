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

            var url = @"https://swapi.dev";
            var client = new HttpClient() { BaseAddress = new Uri(url) };
            var result = await client.GetAsync($"api/films/{id}/");
            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                var film = JsonSerializer.Deserialize<Film>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                Console.WriteLine(film.Title);
                film.ShowInfo(client);

                foreach (var character in film.Characters) {
                    var uri = new Uri(character);
                    var ans =  await client.GetAsync(uri.AbsolutePath);
                    if (ans.IsSuccessStatusCode) {
                        var charAns = await ans.Content.ReadAsStringAsync();
                        var newCharacter = JsonSerializer.Deserialize<Character>(charAns);
                        System.Console.WriteLine(newCharacter.name);
                        System.Console.WriteLine(newCharacter.hair_color);
                        System.Console.WriteLine();

                    }
                }
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
