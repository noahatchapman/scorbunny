namespace Cpsc370Final;

public class Damage
{
    public readonly Random random = new Random();

    public int Attack()
    {
        double critMultiplier = random.Next(100) < 15 ? 1.5 : 1.0;
        double typeMultiplier = TypeAdvantage[Type] == opponentType ? 1.5 : 1.0;
        return (int)(random.Next(10,26) * critMultiplier * typeMultiplier);
    }

    public bool Dodging()
    {
        return random.Next(100) < 15;
    }
}