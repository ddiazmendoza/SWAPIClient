using System; 
using System.Net; 
using System.Net.Http;
using System.Text.Json;

namespace SwapiClient
{
     public class Film 
     {
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

        public async void ShowInfo(HttpClient client)
         
        {
            System.Console.WriteLine(Title);
            System.Console.WriteLine("Episode " + Episode_Id.ToString());
            System.Console.WriteLine(Director);
            System.Console.WriteLine(Opening_crawl);
            System.Console.WriteLine(Created.ToShortDateString());
            System.Console.WriteLine(Url);

            foreach (var character in Characters) 
            {
                var characterUri = new Uri(character);
                var characterResponse =  await client.GetAsync(characterUri.AbsolutePath);
                
                if (characterResponse.IsSuccessStatusCode) 
                {
                    var characterContent = await characterResponse.Content.ReadAsStringAsync();
                    var newCharacter = JsonSerializer.Deserialize<Character>(characterContent);
                    newCharacter.ShowInfo();
                }
            }
        }
    }
}