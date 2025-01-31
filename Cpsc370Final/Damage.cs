using System.Net;

namespace Cpsc370Final;

public static class Damage
{
    public static readonly Random random = new Random();
    public static bool isCrit;
    public static bool isSuperEffective;
    

    public static int Attack(string attackerType, string defenderType)
    {
        double critMultiplier = random.Next(100) < 15 ? 1.5 : 1.0;
        checKIfCrit(critMultiplier);
        double typeMultiplier = GetTypeMultiplier(attackerType, defenderType);
        checkIfSuperEffective(typeMultiplier);
        return (int)(random.Next(10,26) * critMultiplier * typeMultiplier);
    }

    private static void checkIfSuperEffective(double typeMultiplier)
    {
        if (typeMultiplier == 1.5)
        {
            isSuperEffective = true;
        }
        else
        {
            isSuperEffective = false;
        }
    }

    public static void checKIfCrit(double crit)
    {
        if (crit == 1.5)
        {
            isCrit = true;
        }
        else
        {
            isCrit = false;
        }
    }

    private static double GetTypeMultiplier(string attackerType, string defenderType)
    {
        if ((attackerType == "Fire" && (defenderType == "Grass" || defenderType == "Ice" || defenderType == "Bug" ||
                                        defenderType == "Steel")) ||
            (attackerType == "Water" &&
             (defenderType == "Fire" || defenderType == "Ground" || defenderType == "Rock")) ||
            (attackerType == "Grass" &&
             (defenderType == "Water" || defenderType == "Ground" || defenderType == "Rock")) ||
            (attackerType == "Electric" && (defenderType == "Water" || defenderType == "Flying")) ||
            (attackerType == "Ground" && (defenderType == "Electric" || defenderType == "Fire" ||
                                          defenderType == "Poison" || defenderType == "Rock" ||
                                          defenderType == "Steel")) ||
            (attackerType == "Psychic" && (defenderType == "Fighting" || defenderType == "Poison")) ||
            (attackerType == "Fighting" && (defenderType == "Normal" || defenderType == "Ice" ||
                                            defenderType == "Rock" || defenderType == "Dark" ||
                                            defenderType == "Steel")) ||
            (attackerType == "Ice" && (defenderType == "Dragon" || defenderType == "Flying" ||
                                       defenderType == "Grass" || defenderType == "Ground")) ||
            (attackerType == "Rock" && (defenderType == "Fire" || defenderType == "Ice" || defenderType == "Flying" ||
                                        defenderType == "Bug")) ||
            (attackerType == "Ghost" && (defenderType == "Psychic" || defenderType == "Ghost")) ||
            (attackerType == "Dark" && (defenderType == "Psychic" || defenderType == "Ghost")) ||
            (attackerType == "Steel" && (defenderType == "Ice" || defenderType == "Rock" || defenderType == "Fairy")))
        {
            return 1.5;
        }

        return 1.0;
    }
}