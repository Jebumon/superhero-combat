namespace SuperheroAPI.Models
{
    public struct CombatResult
    {
        public string Winner { get; private set; }
        public WinMargin WinMargin { get; private set; }

        public CombatResult(string winner, WinMargin winMargin)
        {
            Winner = winner;
            WinMargin = winMargin;
        }
    }
}
