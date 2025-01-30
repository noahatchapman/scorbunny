namespace Cpsc370Final;
using System.Text.RegularExpressions;

public class Player
{
    public String userName;
    public Pokemon playersPokemon = new Pokemon();
    public bool isPlayerOne = false;

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
    
    }
