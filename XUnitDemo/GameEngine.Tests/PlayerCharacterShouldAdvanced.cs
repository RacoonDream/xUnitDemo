using GameEngine.Tests.TestData;
using System;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    [Trait("Category", "PlayerAdvanced")]
    public class PlayerCharacterShouldAdvanced:IDisposable
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly PlayerCharacter _sut;
        public PlayerCharacterShouldAdvanced(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _sut = new PlayerCharacter();
        }

        [Fact]
        public void IsSet_PlayerCharacter_FirstName()
        {
            // Arrange

            // Act
            _sut.FirstName = "Link";

            // Assert
            Assert.Equal("Link", _sut.FirstName);

        }

        [Fact]
        public void IsNewbie_OnPlayerCreation()
        {
            // Arrange
            //PlayerCharacter sut = new PlayerCharacter();
            // Act

            // Assert
            Assert.True(_sut.IsNewbie);
        }

        [Fact]
        public void HaveAllRequiredWeapons()
        {
            // Arrange

            // Act
            _testOutputHelper.WriteLine("Creating Weapons...");
            var expectedWeapons = new[]
            {
                "Long Bow",
                "Short Bow",
                "Short Sword",
            };

            // Assert
            Assert.Equal(expectedWeapons, _sut.Weapons);

        }
        [Fact]
        public void NoEmptyWeaponsCreated()
        {
            // Arrange

            // Act


            // Assert
            Assert.All(_sut.Weapons, weapon => Assert.False(string.IsNullOrEmpty(weapon)));

        }


        [Trait("TestType", "Data-Driven")]
        [Theory]
        [InlineData(0, 100)]
        [InlineData(1, 99)]
        [InlineData(50, 50)]
        [InlineData(101, 1)]
        public void TakeDamageInline(int damage, int expectedHealth)
        {
            _sut.TakeDamage(damage);

            Assert.Equal(expectedHealth, _sut.Health);
        }

        [Trait("TestType", "Data-Driven")]
        [Theory]
        [MemberData(nameof(InternalHealthDamageTestData.TestData),
           MemberType = typeof(InternalHealthDamageTestData))]
        public void TakeDamageInternal(int damage, int expectedHealth)
        {
            _sut.TakeDamage(damage);

            Assert.Equal(expectedHealth, _sut.Health);
        }

        [Trait("TestType", "Data-Driven")]
        [Theory]
        [MemberData(nameof(ExternalHealthDamageTestData.TestData),
           MemberType = typeof(ExternalHealthDamageTestData))]
        public void TakeDamage(int damage, int expectedHealth)
        {
            _sut.TakeDamage(damage);

            Assert.Equal(expectedHealth, _sut.Health);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
