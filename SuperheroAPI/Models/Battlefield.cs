namespace SuperheroAPI.Models
{
    public struct Battlefield
    {
        public readonly string Name;
        public readonly float CombatMod;
        public readonly float DurabilityMod;
        public readonly float IntelligenceMod;
        public readonly float PowerMod;
        public readonly float SpeedMod;
        public readonly float StrengthMod;

        public Battlefield(string name, float combatMod, float durabilityMod, float intelligenceMod, float powerMod, float speedMod, float strengthMod)
        {
            Name = name;
            CombatMod = combatMod;
            DurabilityMod = durabilityMod;
            IntelligenceMod = intelligenceMod;
            PowerMod = powerMod;
            StrengthMod = strengthMod;
            SpeedMod = speedMod;
        }
    }
}
