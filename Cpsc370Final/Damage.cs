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
        if ((attackerType == "fire" && (defenderType == "grass" || defenderType == "ice" || defenderType == "bug" ||
                                        defenderType == "steel")) ||
            (attackerType == "water" &&
             (defenderType == "fire" || defenderType == "ground" || defenderType == "rock")) ||
            (attackerType == "grass" &&
             (defenderType == "water" || defenderType == "ground" || defenderType == "rock")) ||
            (attackerType == "electric" && (defenderType == "water" || defenderType == "flying")) ||
            (attackerType == "ground" && (defenderType == "electric" || defenderType == "fire" ||
                                          defenderType == "poison" || defenderType == "rock" ||
                                          defenderType == "steel")) ||
            (attackerType == "psychic" && (defenderType == "fighting" || defenderType == "poison")) ||
            (attackerType == "fighting" && (defenderType == "normal" || defenderType == "ice" ||
                                            defenderType == "rock" || defenderType == "dark" ||
                                            defenderType == "steel")) ||
            (attackerType == "ice" && (defenderType == "dragon" || defenderType == "flying" ||
                                       defenderType == "grass" || defenderType == "ground")) ||
            (attackerType == "rock" && (defenderType == "fire" || defenderType == "ice" || defenderType == "flying" ||
                                        defenderType == "bug")) ||
            (attackerType == "ghost" && (defenderType == "psychic" || defenderType == "ghost")) ||
            (attackerType == "dark" && (defenderType == "psychic" || defenderType == "ghost")) ||
            (attackerType == "steel" && (defenderType == "ice" || defenderType == "rock" || defenderType == "fairy")))
        {
            return 1.5;
        }

        return 1.0;
    }
}