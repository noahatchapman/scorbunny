namespace Cpsc370Final;

public class Damage
{
    public readonly Random random = new Random();

    public int Attack()
    {
        double critMultiplier = random.Next(100) < 15 ? 1.5 : 1.0;
        double typeMultiplier = GetTypeMultiplier(Type, opponent.Type);
        return (int)(random.Next(10,26) * critMultiplier * typeMultiplier);
    }

    public bool Dodging()
    {
        return random.Next(100) < 15;
    }

    private double GetTypeMultiplier(string attackerType, string defenderType)
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