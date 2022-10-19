using Newtonsoft.Json;
using SuperheroAPI.Models;
using System.Collections.Generic;

namespace SuperheroAPI.Repository
{
    public class API_handler
    {
        private readonly string URL = "https://www.superheroapi.com/api.php/";
        private readonly string API_ACCESS_TOKEN = "102858579285044";
        private string response = "";
        HttpClient client = new HttpClient();

        private string[] _contestants { get; set; }
        List<Contestant> contestantsList = new List<Contestant>();
        public API_handler(string[] contestants)
        {
            _contestants = contestants;
            Console.WriteLine(string.Join(",", _contestants)+"\n");
        }

        public List<Contestant> GetContestantsList() 
        {
            GetDataAsync().Wait();
            return contestantsList;
        }
        public async Task GetDataAsync() 
        {
            foreach (string contestant in _contestants)
            {
                await GetJSON(contestant);
                var contestantObject = ConvertJSON();
                contestantsList.Add(contestantObject);
            }
        }
        public async Task GetJSON(string contestant)
        {
            response = await client.GetStringAsync(URL + API_ACCESS_TOKEN + "/search/" + contestant);
            //Console.WriteLine(response);
        }
        public Contestant ConvertJSON()
        {
            string name = "";
            int combat = 0;
            int durability = 0;
            int intelligence = 0;
            int power = 0;
            int speed = 0;
            int strength = 0;

            var contestantsList = JsonConvert.DeserializeObject<JSON_Objects>(response);
           
            foreach (var result in contestantsList.Results)
            {
                name = contestantsList.ResultsFor;
                combat = Int32.Parse(result.Powerstats.Combat);
                durability = Int32.Parse(result.Powerstats.Durability);
                intelligence = Int32.Parse(result.Powerstats.Intelligence);
                power = Int32.Parse(result.Powerstats.Power);
                speed = Int32.Parse(result.Powerstats.Speed);
                strength = Int32.Parse(result.Powerstats.Strength);

                /*Console.WriteLine("Name : " + name);
                Console.WriteLine("Durability : " + durability);
                Console.WriteLine("Intelligence : " + intelligence);
                Console.WriteLine("Combat : " + combat);
                Console.WriteLine("Power : " + power);
                Console.WriteLine("Speed : " + speed);
                Console.WriteLine("Strength : " + strength);*/
                
            }
            Contestant contestantObject = new Contestant(name, combat, durability, intelligence, power, speed, strength);
            return contestantObject;
        }
    }
}
