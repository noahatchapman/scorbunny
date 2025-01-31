using Cpsc370Final;
using Xunit;

namespace Cpsc370Final.Tests
{
    public class PokemonTests
    {
        [Fact]
        public void TestCreatePokemon()
        {
            // Arrange: Mocking the FileReader static properties to simulate random Pokémon data
            FileReader.filePokeName = "Charmander";
            FileReader.filePokeType = "Fire";
            FileReader.filePokeMove = "Ember";

            // Act
            Pokemon pokemon = new Pokemon();
            pokemon.createPokemon();

            // Assert
            Assert.Equal("Charmander", pokemon.pokeName);
            Assert.Equal("Fire", pokemon.pokeType);
            Assert.Equal("Ember", pokemon.pokeMove);
            Assert.Equal(100, pokemon.pokeHP);  // HP should be reset to 100
            Assert.False(pokemon.isFainted);  // Pokémon shouldn't be fainted initially
        }

        [Fact]
        public void TestDrainHP()
        {
            // Arrange
            Pokemon pokemon = new Pokemon();
            pokemon.pokeHP = 100; // Initial HP

            // Act
            pokemon.drainHP(30);  // Drain 30 HP

            // Assert
            Assert.Equal(70, pokemon.pokeHP);  // HP should now be 70
        }

        [Fact]
        public void TestCheckIfFainted_Fainted()
        {
            // Arrange
            Pokemon pokemon = new Pokemon();
            pokemon.pokeHP = 0; // Pokémon HP is 0, should be fainted

            // Act
            pokemon.checkIfFainted();

            // Assert
            Assert.True(pokemon.isFainted);  // Pokémon should be fainted
        }

        [Fact]
        public void TestCheckIfFainted_NotFainted()
        {
            // Arrange
            Pokemon pokemon = new Pokemon();
            pokemon.pokeHP = 50; // Pokémon HP is 50, should not be fainted

            // Act
            pokemon.checkIfFainted();

            // Assert
            Assert.False(pokemon.isFainted);  // Pokémon should not be fainted
        }
        
    }
}
