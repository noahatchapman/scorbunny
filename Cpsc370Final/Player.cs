namespace Cpsc370Final;
using System.Text.RegularExpressions;

public class Player
{
    public String userName;
    //public Pokemon playersPokemon;
    private bool isPlayerOne;


    public void getUsername()
    {
        Console.Write("Enter a username (letters and numbers only): ");
        string userInput = Console.ReadLine();
        
        while (!IsValidUsername(userInput))
        {
            Console.Write("Invalid username. Please use only letters and numbers: ");
            userInput = Console.ReadLine();
        }
        
        userName = userInput;
        Console.WriteLine($"Username set to: {userName}");
    }
    
    private bool IsValidUsername(string input)
    {
        foreach (char c in input)
        {
            if (!char.IsLetterOrDigit(c))
            {
                return false;
            }
        }
        return true;
    }
    
    public string GetUserName()
    {
        return userName;
    }
    
    }
        // TODO: get user input, can only be letters or numbers, if not keep asking for user input, until they enter a valid name*/
        // then set the variable userName to the userInput
    

   // public void getPlayersPokemon()
    //{
       // playersPokemon.createPokemon();
    //}
