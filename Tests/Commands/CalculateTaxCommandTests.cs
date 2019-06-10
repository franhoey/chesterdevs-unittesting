using ChesterDevsUnitTests.Commands;
using Moq;
using Xunit;

namespace Tests.Commands
{
    public class CalculateTaxCommandTests
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(10000, 0)]
        [InlineData(10001, 0.2)]
        [InlineData(47500, 7500)]
        [InlineData(47501, 7500.4)]
        [InlineData(160000, 52500)]
        [InlineData(160001, 52500.45)]
        public void When_BelowAllowance_Then_Returns_0(decimal income, decimal expectedTax)
        {
            var mockPersonalAllowanceCalculator = new Mock<ICalculatePersonalAllowanceCommand>();

            mockPersonalAllowanceCalculator.Setup(m => m.CalculatePersonalAllowance(It.IsAny<string>()))
                .Returns(10000);

            var objectUnderTest = new CalculateTaxCommand(mockPersonalAllowanceCalculator.Object);

            var result = objectUnderTest.CalculateTax("anything", income);

            Assert.Equal(expectedTax, result);
        }
        
    }
}