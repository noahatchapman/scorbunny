namespace Cpsc370Final;

public class Game
{
    public Player firstPlayer;
    public Player secondPlayer;
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
            GivePokemon(); // to the isPlayerOne = true
            GiveRerollOption(firstPlayer); // tell them if they reroll they have to stick wtih it
            ClearConsole();
            GivePokemon(); // to the !isPlayerOne = false
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

    private void GivePokemon()
    {
        if (firstPlayer.isPlayerOne)
        {
            firstPlayer.playersPokemon.createPokemon();
        }
        else
        {
            secondPlayer.playersPokemon.createPokemon();
        }
    }

    private void DecidePlayerOne()
    {
        //true = first player
        //false = second player
        Boolean isFirstPlayerPlayerOne = ((random.Next(100)) > 50);
        if(isFirstPlayerPlayerOne)
        {
            firstPlayer.isPlayerOne = true;
        }
        else
        {
            secondPlayer.isPlayerOne = true;
        }
    }


    public void StartBattleSimulation()
    {
        int turnCounter = 1;
        while (!firstPlayer.playersPokemon.isFainted && !secondPlayer.playersPokemon.isFainted)
        {
            
            //enter battle stuff
            Console.WriteLine("Battle Start!");
            Console.WriteLine(firstPlayer.userName);
            firstPlayer.playersPokemon.printPokemonInfo();
            Console.WriteLine("against" + secondPlayer.userName);
            secondPlayer.playersPokemon.printPokemonInfo();
            Console.WriteLine("!");

            if (checkTurn(turnCounter))
            {
                int damageAmount;
                damageAmount = Damage.Attack(firstPlayer.playersPokemon.pokeType, secondPlayer.playersPokemon.pokeType);
                secondPlayer.playersPokemon.drainHP(damageAmount);
            }
            else
            {
                int damageAmount;
                damageAmount = Damage.Attack(secondPlayer.playersPokemon.pokeType, firstPlayer.playersPokemon.pokeType);
                firstPlayer.playersPokemon.drainHP(damageAmount);
            }
        }
    }

    private bool checkTurn(int turnCounter)
    {
        //Odd numbers means isPlayerOne's turn
        if (turnCounter % 2 == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void ClearConsole()
    {
        Console.Clear();
    }
}