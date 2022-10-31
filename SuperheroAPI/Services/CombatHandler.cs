using System.Collections;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.VisualBasic;
using SuperheroAPI.Models;

namespace SuperheroAPI.Services
{
    public class CombatHandler
    {

        public CombatHandler()
        {
        }

        public CombatResult DoCombat(List<Contestant> ContestantList, Battlefield battlefield)
        {
            float eachContestantScore = 0.0f;
            float diff = 0.0f;
            float eachContestantPower = 0.0f;
            float eachContestantCombat = 0.0f;
            float eachContestantDurability = 0.0f;
            float eachContestantStrength = 0.0f;
            float eachContestantIntelligence = 0.0f;
            float eachContestantSpeed = 0.0f;
            float highestScore = 0.0f;
            string winner = "";
            int CLOSED_CALL_VALUE = 45;
            int SOLID_WIN_VALUE = 110;
            WinMargin winMarginValue = WinMargin.CloseCall;

            foreach (Contestant ContestantDetails in ContestantList)
            {                
                eachContestantPower = ContestantDetails.Power * battlefield.PowerMod;
                eachContestantCombat = ContestantDetails.Combat * battlefield.CombatMod;
                eachContestantDurability = ContestantDetails.Durability * battlefield.DurabilityMod;
                eachContestantStrength = ContestantDetails.Strength * battlefield.StrengthMod;
                eachContestantIntelligence = ContestantDetails.Intelligence * battlefield.IntelligenceMod;
                eachContestantSpeed = ContestantDetails.Speed * battlefield.SpeedMod;

                eachContestantScore = eachContestantPower + eachContestantCombat + eachContestantDurability + eachContestantStrength + eachContestantIntelligence + eachContestantSpeed;
               
                if (eachContestantScore > highestScore)
                {
                    diff = eachContestantScore - highestScore;
                    highestScore = eachContestantScore;
                    winner = ContestantDetails.Name;                   
                }
                else
                {
                    diff = highestScore - eachContestantScore;                   
                }
            }

            if (diff == 0)
            {
                winMarginValue = WinMargin.Tie;
                winner = "Both are winners";
            }
            else if (diff < CLOSED_CALL_VALUE)
            {
                winMarginValue = WinMargin.CloseCall;
            }
            else if (diff > CLOSED_CALL_VALUE && diff < SOLID_WIN_VALUE)
            {
                winMarginValue = WinMargin.SolidWin;
            }
            else if (diff > SOLID_WIN_VALUE)
            {
                winMarginValue = WinMargin.NoChance;
            }
            return new CombatResult(winner, winMarginValue);
        }
    }
}
