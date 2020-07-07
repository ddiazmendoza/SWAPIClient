using System;

namespace SwapiClient 
{
    public class Character 
    {
        public string name { get; set; }
        public string hair_color { get; set; }

        public async void ShowInfo() 
        {
            System.Console.WriteLine(name);

        }

    }
}