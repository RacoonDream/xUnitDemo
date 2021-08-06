using System;
using Xunit;

namespace GameEngine.Tests
{
    [Trait("Category","Enemy Factory")]
   public class EnemyFactoryShould
    {
        [Fact]
        public void CreateNormalEnemyByDefault()
        {
            EnemyFactory enemyFactory = new EnemyFactory();
            Enemy newEnemy= enemyFactory.Create("Dragon");
            Assert.IsType<NormalEnemy>(newEnemy);
        }

        [Fact]
        public void NotAllowNullName()
        {
            EnemyFactory sut = new EnemyFactory();

             Assert.Throws<ArgumentNullException>(() => sut.Create(null));
           // Assert.Throws<ArgumentNullException>("name", () => sut.Create(null));
        }
    }
}
