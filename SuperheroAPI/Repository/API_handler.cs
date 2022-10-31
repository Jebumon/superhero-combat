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
        private Contestant _contestantObject { get; set; } = new("", "", 0, 0, 0, 0, 0, 0);

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
                throw new BadHttpRequestException(message: "API error(May be due to low internet speed!)");
            }
        }
        public void ConvertJSON(string contestant, string inputRealName)
        {
            string tempName = "", tempRealName = "";

            var contestantsObjects = JsonConvert.DeserializeObject<JSON_Objects>(response);
            if (contestantsObjects.Response == "success")
            {
                foreach (var result in contestantsObjects.Results)
                {
                    try
                    {
                        tempName = result.Name;
                        tempRealName = result.Biography.FullName;
                        _contestantObject = new Contestant(result.Name, result.Biography.FullName, 
                            Int32.Parse(result.Powerstats.Combat), Int32.Parse(result.Powerstats.Durability), 
                            Int32.Parse(result.Powerstats.Intelligence), Int32.Parse(result.Powerstats.Power), 
                            Int32.Parse(result.Powerstats.Speed), Int32.Parse(result.Powerstats.Strength));
                    }
                    catch (Exception)
                    {
                    }
                    if (_contestantObject.Combat * _contestantObject.Durability * _contestantObject.Intelligence * _contestantObject.Power * _contestantObject.Speed * _contestantObject.Strength != 0 )
                    {
                        if (inputRealName == "GetAllNamed")
                        {
                            if (this.contestantsList.Exists(x => x.RealName == _contestantObject.RealName))
                            {
                                break;
                            }
                            else
                            {
                                this.contestantsList.Add(_contestantObject);
                                _contestantObject = new Contestant("", "", 0, 0, 0, 0, 0, 0);
                            }
                        }
                        if (_contestantObject.Name == contestant && _contestantObject.RealName == inputRealName || _contestantObject.Name == contestant && inputRealName == "")
                        {
                            if (this.contestantsList.Exists(x => x.Name == _contestantObject.Name))
                            {
                                throw new AggregateException($"There is more than one {_contestantObject.Name}!! Please enter their Real name");
                               
                            }
                            else
                            {
                                this.contestantsList.Add(_contestantObject);
                                _contestantObject = new Contestant("", "", 0, 0, 0, 0, 0, 0);
                            }
                        }
                    }
                    else 
                    {
                        Console.WriteLine($"{tempName} / {tempRealName}  - Powerstat zero error");
                        //throw new AggregateException($"{tempName} / {tempRealName}  - Powerstat zero error");
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
