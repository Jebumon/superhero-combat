namespace SuperheroAPI.Models
{
    public class Contestant
    {
        public readonly string Name;
        public readonly int Combat;
        public readonly int Durability;
        public readonly int Intelligence;
        public readonly int Power;
        public readonly int Strength;
        public readonly int Speed;

        public Contestant(string name, int combat, int durability, int intelligence, int power, int strength, int speed)
        {
            //edge cases?

            Name = name;
            Combat = combat;
            Durability = durability;
            Intelligence = intelligence;
            Power = power;
            Strength = strength;
            Speed = speed;
        }
    }
}
