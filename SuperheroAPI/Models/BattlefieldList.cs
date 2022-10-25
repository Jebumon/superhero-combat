namespace SuperheroAPI.Models
{
    public static class BattlefieldList
    {
        private static readonly List<Battlefield> battlefields = new()
        {
            new Battlefield("Volcano", 0.7f, 1f, 0.4f, 0.7f, 0.5f, 0.7f),
            new Battlefield("Area51", 0.7f, 0.7f, 1f, 0.5f, 0.5f, 0.6f),
            new Battlefield("HighGPlanet", 0.9f, 0.9f, 0.3f, 0.8f, 1f, 0.1f),
            new Battlefield("Multiverse", 0.6f, 0.6f, 0.6f, 1f, 0.6f, 0.6f),
            new Battlefield("BankVault", 1f, 0.9f, 0.1f, 0.9f, 0.9f, 0.2f),
            new Battlefield("OpenField", 0.7f, 0.7f, 0.2f, 0.8f, 0.6f, 1f)
        };

        public static Battlefield GetBattlefield(string name)
        {
            Battlefield? battlefield = null;
            foreach (Battlefield b in battlefields)
            {
                if (b.Name == name)
                {
                    battlefield = b;
                    break;
                }
            }

            if (battlefield == null)
                throw new Exception("The battlefield cannot be found.");
            else
                return (Battlefield)battlefield;
        }
    }
}
