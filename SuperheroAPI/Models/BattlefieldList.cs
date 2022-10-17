namespace SuperheroAPI.Models
{
    public static class BattlefieldList
    {
        private static readonly List<Battlefield> battlefields = new()
        {
            new Battlefield("Volcano", 0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f),
            new Battlefield("Space", 0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f),
            new Battlefield("Underwater", 0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f),
            new Battlefield("Multiverse", 0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f),
            new Battlefield("placeholder1", 0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f),
            new Battlefield("placeholder2", 0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f)
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
