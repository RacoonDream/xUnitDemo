using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    public class GameStateShould_Simple
    {

        private readonly ITestOutputHelper _output;

        public GameStateShould_Simple(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void DamageAllPlayersWhenEarthquake()
        {

           
            var player1 = new PlayerCharacter();
            var player2 = new PlayerCharacter();
            List<PlayerCharacter> players = new List<PlayerCharacter>();

            players.Add(player1);
            players.Add(player2);

            var expectedHealthAfterEarthquake = player1.Health - GameState.EarthquakeDamage;

            GameState gameState = new GameState();
            gameState.Players = players;
            gameState.Earthquake();

            Assert.Equal(expectedHealthAfterEarthquake, player1.Health);
            Assert.Equal(expectedHealthAfterEarthquake, player2.Health);
        }

        [Fact]
        public void Reset()
        {
            var player1 = new PlayerCharacter();
            var player2 = new PlayerCharacter();
            List<PlayerCharacter> players = new List<PlayerCharacter>();

            players.Add(player1);
            players.Add(player2);

            GameState gameState = new GameState();
            gameState.Players = players;
            gameState.Reset();

            Assert.Empty(gameState.Players);
        }


    }
}
