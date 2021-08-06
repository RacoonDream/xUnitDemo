using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    public class GameStateShould_Refer :IClassFixture<GameStateFixture>
    {

        private readonly ITestOutputHelper _output;
        private readonly GameStateFixture _gameStateFixture;
        public GameStateShould_Refer (ITestOutputHelper output,GameStateFixture gameStateFixture)
        {
            _output = output;
            _gameStateFixture = gameStateFixture;
        }

        [Fact]
        [Trait("TestType","WithFixture")]
        public void DamageAllPlayersWhenEarthquake()
        {

            _output.WriteLine($"GameStateID =  {_gameStateFixture.GameState.Id}");
            var player1 = new PlayerCharacter();
            var player2 = new PlayerCharacter();
            //List<PlayerCharacter> players = new List<PlayerCharacter>();

            //players.Add(player1);
            //players.Add(player2);

            _gameStateFixture.GameState.Players.Add(player1);
            _gameStateFixture.GameState.Players.Add(player2);

            var expectedHealthAfterEarthquake = player1.Health - GameState.EarthquakeDamage;

            //GameState gameState = new GameState();
            //gameState.Players = players;
            _gameStateFixture.GameState.Earthquake();

            Assert.Equal(expectedHealthAfterEarthquake, player1.Health);
            Assert.Equal(expectedHealthAfterEarthquake, player2.Health);
        }

        [Fact]
        [Trait("TestType", "WithFixture")]
        public void Reset()
        {
            _output.WriteLine($"GameStateID =  {_gameStateFixture.GameState.Id}");
            var player1 = new PlayerCharacter();
            var player2 = new PlayerCharacter();
            //List<PlayerCharacter> players = new List<PlayerCharacter>();

            //players.Add(player1);
            //players.Add(player2);
            _gameStateFixture.GameState.Players.Add(player1);
            _gameStateFixture.GameState.Players.Add(player2);


            //GameState gameState = new GameState();
            //gameState.Players = players;
            _gameStateFixture.GameState.Reset();

            Assert.Empty(_gameStateFixture.GameState.Players);
        }


    }
}
