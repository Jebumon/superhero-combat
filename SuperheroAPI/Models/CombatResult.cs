namespace SuperheroAPI.Models
{
    public struct CombatResult
    {
        public readonly string Winner;
        public readonly WinMargin WinMargin;

        public CombatResult(string winner, WinMargin winMargin)
        {
            Winner = winner;
            WinMargin = winMargin;
        }
    }
}
