namespace SuperheroAPI.Models
{
    public class Contestant
    {
        public string Name { get; private set; }
        public int Combat { get; private set; }
        public int Durability { get; private set; }
        public int Intelligence { get; private set; }
        public int Power { get; private set; }
        public int Speed { get; private set; }
        public int Strength { get; private set; }

        public Contestant(string name, int combat, int durability, int intelligence, int power, int speed, int strength)
        {
            //edge cases?

            Name = name;
            Combat = combat;
            Durability = durability;
            Intelligence = intelligence;
            Power = power;
            Speed = speed;
            Strength = strength;
        }
    }
}
