namespace Cpsc370Final;

using System;
using System.Collections.Generic;
using System.IO;

public static class FileReader
{
    private static Random _random = new Random();
    
    public static string filePokeName;
    public static string filePokeType;
    public static string filePokeMove;

    private static string filePath = "PokemonNames.txt";

    public static List<string[]> ReadFile()
    {
        List<string[]> result = new List<string[]>();

        try
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] splitLine = line.Split(',');
                for (int i = 0; i < splitLine.Length; i++)
                {
                    splitLine[i] = splitLine[i].Trim();
                }
                result.Add(splitLine);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error reading file: " + e.Message);
        }

        return result;
    }

    public static void GetRandomPokemon()
    {
        List<string[]> data = ReadFile();
        if (data.Count > 0)
        {
            int randomIndex = _random.Next(data.Count);
            SetPokemonInfo(data[randomIndex]);
        }
    }

    private static void SetPokemonInfo(string[] pokemonAsArray)
    {
        if (pokemonAsArray.Length >= 3)
        {
            filePokeName = pokemonAsArray[0];
            filePokeType = pokemonAsArray[1];
            filePokeMove = pokemonAsArray[2];
        }
    }
}