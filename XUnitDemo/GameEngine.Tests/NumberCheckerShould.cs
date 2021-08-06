 
using Xunit;


namespace GameEngine.Tests
{
   public class NumberCheckerShould
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [Trait("TestType","DataDriven")]
        public void TestOddNumbers(int num)
        {
            NumberChecker sut = new NumberChecker();
            Assert.True(sut.IsOddNumber(num));
        }
    }
}
