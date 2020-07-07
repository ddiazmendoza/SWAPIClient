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

    public class Film {
        public string Title { get; set; }
        public int Episode_Id { get; set; }
        public string Opening_crawl { get; set; }
        public string Director { get; set; }
        public string[] Characters { get; set; }
        public DateTime Created {get; set;} 
        public string Url { get; set; }

        public Film() 
        {
            System.Console.WriteLine("New film consultated...");
        } 

        public void ShowInfo() 
        {
            System.Console.WriteLine(Title);
            System.Console.WriteLine("Episode " + Episode_Id.ToString());
            System.Console.WriteLine(Director);
            System.Console.WriteLine(Opening_crawl);
            System.Console.WriteLine(Created.ToShortDateString());
            System.Console.WriteLine(Url);

            foreach (var character in Characters) 
            
            {
                System.Console.WriteLine(character);
            }
        }
    }
}
