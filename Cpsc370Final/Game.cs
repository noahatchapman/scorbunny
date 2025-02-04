namespace Cpsc370Final;

public class Game
{
    public Player firstPlayer = new Player();
    public Player secondPlayer = new Player();
    public bool isContinuing = true;
    public readonly Random random = new Random();

    public void startGame()
    {
        FileReader.ReadFile();
        Console.WriteLine("~~Welcome to a 1v1 Pokemon Battle Simulation!~~");
        Console.WriteLine("First Player");
        firstPlayer.getUsername();
        Console.WriteLine("Second Player:");
        secondPlayer.getUsername();
        
        while (isContinuing)
        {
            GivePokemon(firstPlayer); 
            GiveRerollOption(firstPlayer); // tell them if they reroll they have to stick wtih it
            Thread.Sleep(2500);
            ClearConsole();
            GivePokemon(secondPlayer); 
            GiveRerollOption(secondPlayer); //tell them if they reroll they have to stick wtih it
            Thread.Sleep(2500);
            ClearConsole();
            DecidePlayerOne();
            StartBattleSimulation();
            AskToContinue();

        }
        
        Console.WriteLine("Thank you for playing!");

    }

    private void AskToContinue()
    {
        Console.WriteLine("Would you like to continue (yes/no): ");
        String userInput = Console.ReadLine();
        while (userInput != "yes" && userInput != "no")
        {
            Console.WriteLine("Invalid input. Please enter 'yes' or 'no': ");
            userInput = Console.ReadLine();
        }
        isContinuing = userInput == "yes";
    }

    private void GiveRerollOption(Player player)
    {
        Console.WriteLine("Would you like to reroll? Answer 'yes' or 'no'. You only get one reroll!");
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


    private void StartBattleSimulation()
    {
        int turnCounter = 1;

        Console.WriteLine("Battle Start!");
        Thread.Sleep(2000);
        Console.WriteLine($"{firstPlayer.userName} with {firstPlayer.playersPokemon.pokeName} vs {secondPlayer.userName} with {secondPlayer.playersPokemon.pokeName}!");
        Thread.Sleep(2000);
        
        while (!firstPlayer.playersPokemon.isFainted && !secondPlayer.playersPokemon.isFainted)
        {
            Player attackingPlayer = checkTurn(turnCounter) ? firstPlayer : secondPlayer;
            Player defendingPlayer = checkTurn(turnCounter) ? secondPlayer : firstPlayer;
            
            Console.WriteLine($"{attackingPlayer.userName}'s turn! {attackingPlayer.playersPokemon.pokeName} attacks with {attackingPlayer.playersPokemon.pokeMove}!");
            Thread.Sleep(2000);
            int damageAmount = Damage.Attack(attackingPlayer.playersPokemon.pokeType, defendingPlayer.playersPokemon.pokeType);
            defendingPlayer.playersPokemon.drainHP(damageAmount);
            
            Console.WriteLine($"{defendingPlayer.playersPokemon.pokeName} took {damageAmount} damage! Remaining HP: {defendingPlayer.playersPokemon.pokeHP}");
            if (Damage.isSuperEffective)
            {
                Console.WriteLine(("Super Effective!"));
            }
            if (Damage.isCrit)
            {
                Console.WriteLine("Critical hit!");
            }
            
            Thread.Sleep(2000);
            
            
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
    private void ClearConsole()
    {
        Console.Clear();
    }
}