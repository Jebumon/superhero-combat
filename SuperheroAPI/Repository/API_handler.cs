using Newtonsoft.Json;
using SuperheroAPI.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SuperheroAPI.Repository
{
    public class API_handler
    {
        private readonly string URL = "https://www.superheroapi.com/api.php/";
        private readonly string API_ACCESS_TOKEN = "102858579285044";
        private string? response { get; set; }
        HttpClient client = new HttpClient();

        private string[] _contestants { get; set; }
        private string[] _inputRealNames { get; set; }
        private List<Contestant> contestantsList = new List<Contestant>();

        public API_handler(Hashtable names) 
        {
            string[] tempContestantNames = new string[names.Count];
            string[] tempInputRealNames = new string[names.Count];
            names.Keys.CopyTo(tempContestantNames, 0);
            names.Values.CopyTo(tempInputRealNames, 0);
            _contestants = tempContestantNames;
            _inputRealNames = tempInputRealNames;
        }

        public List<Contestant> GetContestantsList()
        {
            GetDataAsync().Wait();
            return contestantsList;
        }
        public async Task GetDataAsync()
        {
            int i = 0;
            foreach (string contestant in _contestants)
            {
                string inputRealName = _inputRealNames[i++];
                await GetJSON(contestant);
                ConvertJSON(contestant, inputRealName);
            }
        }
        public async Task GetJSON(string contestant)
        {
            try
            {
                response = await client.GetStringAsync(URL + API_ACCESS_TOKEN + "/search/" + contestant);
            }
            catch (Exception)
            {
                Console.WriteLine("API error(May be due to low internet speed!)");
            }
        }
        public void ConvertJSON(string contestant, string inputRealName)
        {
            string name = "";
            string realName = "";
            int combat = 0;
            int durability = 0;
            int intelligence = 0;
            int power = 0;
            int speed = 0;
            int strength = 0;

            var contestantsObjects = JsonConvert.DeserializeObject<JSON_Objects>(response);
            if (contestantsObjects.Response == "success")
            {
                foreach (var result in contestantsObjects.Results)
                {
                    try
                    {
                        name = result.Name;
                        realName = result.Biography.FullName;
                        combat = Int32.Parse(result.Powerstats.Combat);
                        durability = Int32.Parse(result.Powerstats.Durability);
                        intelligence = Int32.Parse(result.Powerstats.Intelligence);
                        power = Int32.Parse(result.Powerstats.Power);
                        speed = Int32.Parse(result.Powerstats.Speed);
                        strength = Int32.Parse(result.Powerstats.Strength);
                    }
                    catch (Exception)
                    {
                    }
                    if (combat * durability * intelligence * power * speed * strength != 0)
                    {
                        if (inputRealName == "GetAllNamed")
                        {
                            Contestant contestantObject = new Contestant(name, realName, combat, durability, intelligence, power, speed, strength);
                            if (this.contestantsList.Exists(x => x.RealName == realName))
                            {
                                break;
                            }
                            else
                            {
                                this.contestantsList.Add(contestantObject);
                                combat = 0;
                                durability = 0;
                                intelligence = 0;
                                power = 0;
                                speed = 0;
                                strength = 0;
                            }
                        }
                        if (name == contestant && inputRealName == realName || name == contestant && inputRealName == "")
                        {
                            Contestant contestantObject = new Contestant(name, realName, combat, durability, intelligence, power, speed, strength);
                            if (this.contestantsList.Exists(x => x.Name == name))
                            {
                                throw new ArgumentException($"There is more than one {name}!! Please enter their Real name");
                            }
                            else
                            {
                                this.contestantsList.Add(contestantObject);
                            }
                        }
                    }
                    else 
                    {
                        Console.WriteLine($"{name} / { realName}  - Powerstat zero error");
                    }
                }
            }
            else
            {
                Console.WriteLine("Error that SuperHero not found");
                //throw new InvalidSuperHeroNameException();
            }
        }
    }
}
