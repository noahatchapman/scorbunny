namespace Cpsc370Final;

public class Game
{
    public Player firstPlayer = new Player();
    public Player secondPlayer = new Player();
    public bool isContinuing = true;
    public readonly Random random = new Random();

    public void startGame()
    {
        Console.WriteLine("~~Welcome to a 1v1 Pokemon Battle Simulation!~~");
        Console.WriteLine("First Player");
        firstPlayer.getUsername();
        Console.WriteLine("Second Player:");
        secondPlayer.getUsername();
        
        while (isContinuing)
        {
            DecidePlayerOne();
            GivePokemon(firstPlayer); // to the isPlayerOne = true
            GiveRerollOption(firstPlayer); // tell them if they reroll they have to stick wtih it
            ClearConsole();
            GivePokemon(secondPlayer); // to the !isPlayerOne = false
            GiveRerollOption(secondPlayer); //tell them if they reroll they have to stick wtih it
            ClearConsole();
            StartBattleSimulation();
            
        }

    }

    private void GiveRerollOption(Player player)
    {
        Console.WriteLine("Would you like to reoll? Answer 'yes' or 'no'. You only get one reroll!");
        String userAnswer = Console.ReadLine();
        if (userAnswer == "yes" )
        {
            player.playersPokemon.createPokemon();
        }
        else
        {
            Console.WriteLine("You kept your pokemon!");
        }
    }

    private void GivePokemon(Player player)
    {
            Console.WriteLine($"{player.userName} received:");
            player.playersPokemon.createPokemon();
    }

    private void DecidePlayerOne()
    {
        //true = first player
        //false = second player
        bool isFirstPlayerPlayerOne = ((random.Next(100)) > 50);
        
        firstPlayer.isPlayerOne = isFirstPlayerPlayerOne;
        secondPlayer.isPlayerOne = !isFirstPlayerPlayerOne;
        
        Console.WriteLine($"{(isFirstPlayerPlayerOne ? firstPlayer.userName : secondPlayer.userName)} goes first!");
    }


    public void StartBattleSimulation()
    {
        int turnCounter = 1;

        Console.WriteLine("Battle Start!");
        Console.WriteLine($"{firstPlayer.userName} with {firstPlayer.playersPokemon.pokeName} vs {secondPlayer.userName} with {secondPlayer.playersPokemon.pokeName}!");
        
        while (!firstPlayer.playersPokemon.isFainted && !secondPlayer.playersPokemon.isFainted)
        {
            Player attackingPlayer = checkTurn(turnCounter) ? firstPlayer : secondPlayer;
            Player defendingPlayer = checkTurn(turnCounter) ? secondPlayer : firstPlayer;
            
            Console.WriteLine($"{attackingPlayer.userName}'s turn! {attackingPlayer.playersPokemon.pokeName} attacks!");
            
            int damageAmount = Damage.Attack(attackingPlayer.playersPokemon.pokeType, defendingPlayer.playersPokemon.pokeType);
            defendingPlayer.playersPokemon.drainHP(damageAmount);
            
            Console.WriteLine($"{defendingPlayer.playersPokemon.pokeName} took {damageAmount} damage! Remaining HP: {defendingPlayer.playersPokemon.pokeHP}");
            
            defendingPlayer.playersPokemon.checkIfFainted();
            
            if (defendingPlayer.playersPokemon.isFainted)
            {
                Console.WriteLine($"{defendingPlayer.playersPokemon.pokeName} has fainted! {attackingPlayer.userName} wins!");
                break;
            }

            turnCounter++;
        }
    }

    private bool checkTurn(int turnCounter)
    {
        return turnCounter % 2 == 1;
    }
    public void ClearConsole()
    {
        Console.Clear();
    }
}