    using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using RestClient;

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
            client.DefaultRequestHeaders.Add(
                "Authentication", 
                "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImp0aSI6ImQyZDI4M2Y1OTAwZWQ3MzQ5NGJhNjNmYTc4MjgxNWQxNDZkOTQ4NDhhZDMwZGU0N2Q1MWIyMmQxMTA1MTAzN2IyMDE0Zjk3ZjRkNjUwMzJjIn0.eyJhdWQiOiJScDFqSGV5QklUQWp6YUxWbzlrMkpmOERGOGl1UUhXQyIsImp0aSI6ImQyZDI4M2Y1OTAwZWQ3MzQ5NGJhNjNmYTc4MjgxNWQxNDZkOTQ4NDhhZDMwZGU0N2Q1MWIyMmQxMTA1MTAzN2IyMDE0Zjk3ZjRkNjUwMzJjIiwiaWF0IjoxNTk0MTUwNjA3LCJuYmYiOjE1OTQxNTA2MDcsImV4cCI6MTYyNTY4NjYwNywic3ViIjoiIiwic2NvcGVzIjpbXX0.Pag11F-B3Q8T9oGZYh2m6TD9HGpQZKZgJhQ5ebgXcK0REiHsENuCTImd4QfTYXCAijTYrsHEC4TFBmhaiY_G2QklhpEK0joJQuf2N-HSuP-9R9vpVZLwUmieRiJ255r3g2DYTooVWMilgUS8UDzVm656Ab59GeDtLtVEDvBmHSCBk9KM-bT74TTqULlHFuI_Z3L4kqn4iugB31Z7W9Twu_WoUb-u9HHlKK0STuWr38o5-dOLsx7LsqVrSDqrMwoV5tZJm1puwxscqfPOdEFz2JPZGYrbpDqlqKepegxnPnt73pPGvdV6uBitY5QvuIml897wf_F6dKhHt3p8XuuBphOoum3f-PPzRxHi9Lh92QOEbVA_Q4DH56T-pV4AoVSe3-6pZdB9xzYnYjUYYenfeFocZMyTRXdkTfFNAyq_UlfpKFTYpRXoobmVwEUZZNnzYjxvR3EOAnESgtuYcAOWBz2N8WmLPC8FbTIkgK-Po7nmwq3_uc_lv7rmxwbvdGsPkkTT1QaHDq3zitB83A_xwsh6GTLVt0yOHFg9MOn98cjEXsgcrIkvmPc02BY4MFeQyR5NjVQGg0IIvhMjKEtPmwc8AIKprLCaO0Rq26aabHW-v_A78k78jWD3sbgiLgVt8b4Yekz4g8bO6z70dlsHsr0s0XUX0Tylhmhobrg-zCY");
                
        }
        
    }
}
