namespace SuperheroAPI.Models
{
    public class BattlefieldList
    {
        public readonly List<Battlefield> Battlefields = new()
        {
            new Battlefield("Volcano", 0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f),
            new Battlefield("Space", 0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f),
            new Battlefield("Underwater", 0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f),
            new Battlefield("Multiverse", 0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f),
            new Battlefield("placeholder1", 0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f),
            new Battlefield("placeholder2", 0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f)
        };
    }
}
