using Newtonsoft.Json;
using SuperheroAPI.Models;
namespace SuperheroAPI.Repository
{
    public class API_handler
    {
        //https://www.superheroapi.com/api.php/102858579285044/search/Superman
        private readonly string URL = "https://www.superheroapi.com/api.php/";
        private readonly string API_ACCESS_TOKEN = "102858579285044";
        private string response = "";
        HttpClient client = new HttpClient();

        string[] _contestants { get; set; }

        public API_handler(string[] contestants)
        {
            _contestants = contestants;
            Console.WriteLine(string.Join(",", _contestants));
        }

        public async Task GetJSON()
        {
            response = await client.GetStringAsync(URL + API_ACCESS_TOKEN + "/search/" + _contestants[0]);
            Console.WriteLine(response);
        }
        public void ConvertJSON()
        {
            List<Contestant> contestantsList = JsonConvert.DeserializeObject<List<Contestant>>(response);
            foreach (var item in contestantsList)
            {
                Console.WriteLine("Name : " + item.name);
                Console.WriteLine("Durability : " + item.durability);
                Console.WriteLine("Intelligence : " + item.intelligence);
                Console.WriteLine("Combat : " + item.combat);
                Console.WriteLine("Speed : " + item.speed);
                Console.WriteLine("Strength : " + item.strength);
            }
        }
    }
}
