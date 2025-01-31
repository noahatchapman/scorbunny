namespace Cpsc370Final;

public class Pokemon
{
    public int pokeHP = 100;
    public String pokeName;
    public String pokeType;
    public String pokeMove;
    public bool isFainted;

    public void drainHP(int amount)
    {
        pokeHP -= amount;
    }

    public void createPokemon()
    {
        FileReader.GetRandomPokemon();
        pokeName = FileReader.filePokeName;
        pokeType = FileReader.filePokeType;
        pokeMove = FileReader.filePokeMove;
        pokeHP = 100;
        isFainted = false;
        printPokemonInfo();
    }

    public void checkIfFainted()
    {
        if (pokeHP <= 0)
        {
            isFainted = true;
        }
    }

    public void printPokemonInfo()
    {
        Console.WriteLine("Pokemon: " + pokeName + " Type: " + pokeType + " Move: " + pokeMove);
    }
}