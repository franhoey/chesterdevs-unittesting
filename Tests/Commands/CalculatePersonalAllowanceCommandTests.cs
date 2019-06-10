using ChesterDevsUnitTests.Commands;
using Xunit;

namespace Tests.Commands
{
    public class CalculatePersonalAllowanceCommandTests
    {
        [Fact]
        public void Given_TaxCodeIs1250L_When_CalculatePersonalAllowance_Then_12500()
        {
            var objectUnderTest = new CalculatePersonalAllowanceCommand();

            var result = objectUnderTest.CalculatePersonalAllowance("1250L");

            Assert.Equal(12500, result);
        }
    }
}