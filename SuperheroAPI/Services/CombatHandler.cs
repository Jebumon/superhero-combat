using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using Microsoft.VisualBasic;
using SuperheroAPI.Models;

namespace SuperheroAPI.Services
{
    public class CombatHandler
    {
        private Battlefield battlefield;
        private CombatResult combatResult;

        public CombatHandler()
        {
        }
            
        public CombatResult DoCombat(List<Contestant> ContestantList, Battlefield battlefield) 
        {
            float calculateContestant1Score = 0.0f;
            float calculateContestant2Score = 0.0f;
            float diff1 = 0.0f;
            float diff2 = 0.0f;
            float eachContestantPower = 0.0f;
            float eachContestantCombat = 0.0f;
            float eachContestantDurability = 0.0f;
            float eachContestantStrength = 0.0f;
            float eachContestantIntelligence = 0.0f;
            float eachContestantSpeed = 0.0f;


            foreach (Contestant ContestantDetails in ContestantList)
            {
                eachContestantPower = ContestantDetails.Power * battlefield.PowerMod;
                eachContestantCombat = ContestantDetails.Combat * battlefield.CombatMod;
                eachContestantDurability = ContestantDetails.Durability * battlefield.DurabilityMod;
                eachContestantStrength = ContestantDetails.Strength * battlefield.StrengthMod;
                eachContestantIntelligence = ContestantDetails.Intelligence * battlefield.IntelligenceMod;
                eachContestantSpeed = ContestantDetails.Speed * battlefield.SpeedMod;
                calculateContestant1Score = eachContestantPower + eachContestantCombat + eachContestantDurability + eachContestantStrength + eachContestantIntelligence + eachContestantSpeed;
            }
                
         
            diff1 = calculateContestant1Score - calculateContestant2Score;
            diff2 = calculateContestant2Score - calculateContestant1Score;

            if (calculateContestant1Score > calculateContestant2Score)
            {
            //    combatResult.Winner = contestant1.Name;
                if (diff1 < 10) // difference value for close call needs to be set
                {
                    // win margin should be close call
                }
                else if (diff1 > 10 && diff1 < 50) // difference value for solid win needs to be set
                {
                    //win margin should be solid win
                }
                else if (diff1 > 50) // difference value for no chance needs to be set
                {
                    // win margin should be no chance
                }
            }
            else if (calculateContestant1Score < calculateContestant2Score)
            {
            //    combatResult.Winner = contestant2.Name;
                if (diff2 < 10) // difference value for close call needs to be set
                {
                    // win margin should be close call
                }
                else if (diff2 > 20 && diff2 < 50) // difference value for solid win needs to be set
                {
                    //win margin should be solid win
                }
                else if (diff2 > 50) // difference value for no chance needs to be set
                {
                    // win margin should be no chance
                }
            }
            else if (calculateContestant1Score == calculateContestant2Score)
            {
                // for this scenrio, what are we going to do
            }
            return combatResult;   
        }
    }
}
