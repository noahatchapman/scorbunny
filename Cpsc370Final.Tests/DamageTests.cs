using Cpsc370Final;
using Xunit;

namespace Cpsc370Final.Tests
{
    public class DamageTests
    {

        // Test for super effective
        [Fact]
        public void TestAttack_FireVsGrass()
        {
            // Arrange
            string attackerType = "Fire";
            string defenderType = "Grass";

            // Act
            int damage = Damage.Attack(attackerType, defenderType);

            // Assert: 
            Assert.InRange(damage, 15, 58.5); // Should be multiplied by 1.5x, account for crit for upper bound
            Assert.True(Damage.isSuperEffective);  // Fire is super-effective against Grass
        }

        // Test for Attack method with no super-effective type advantage
        [Fact]
        public void TestAttack_WaterVsGrass_NotSuperEffective()
        {
            // Arrange
            string attackerType = "water";
            string defenderType = "grass";

            // Act
            int damage = Damage.Attack(attackerType, defenderType);

            // Assert: The damage should be between 10 and 26, and the attack should NOT be super-effective
            Assert.InRange(damage, 10, 26);
            Assert.False(Damage.isSuperEffective);  // Water is not super-effective against Grass
        }


    }
}
