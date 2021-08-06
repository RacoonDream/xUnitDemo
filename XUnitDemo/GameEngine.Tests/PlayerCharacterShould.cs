using System;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    [Trait("Category", "Player")]
    public class PlayerCharacterShould
    {
       private readonly ITestOutputHelper _testOutputHelper;
        public PlayerCharacterShould(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void IsSet_PlayerCharacter_FirstName()
        {
            // Arrange
            PlayerCharacter sut = new PlayerCharacter();
            // Act
          //  sut.FirstName = "Link";

            // Assert
           // Assert.Equal("Link", sut.FirstName);
            Assert.NotNull(sut.FirstName);

        }

        [Fact]
        public void IsNewbie_OnPlayerCreation()
        {
            // Arrange
            PlayerCharacter sut = new PlayerCharacter();
            // Act

            // Assert
            Assert.True( sut.IsNewbie);
        }

        [Fact]
        public void HaveAllRequiredWeapons()
        {
            // Arrange
            PlayerCharacter sut = new PlayerCharacter();
            // Act
            _testOutputHelper.WriteLine("Creating Weapons...");
            var expectedWeapons =  new []
            {
                "Long Bow",
                "Short Bow",
                "Short Sword",
            };

            // Assert
            Assert.Equal(expectedWeapons, sut.Weapons );

        }
        [Fact]
        public void NoEmptyWeaponsCreated()
        {
            // Arrange
            PlayerCharacter sut = new PlayerCharacter();
            // Act


            // Assert
            Assert.All(sut.Weapons, weapon => Assert.False(string.IsNullOrEmpty(weapon)));
             
        }


       

    }
}
