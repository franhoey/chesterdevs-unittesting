namespace ChesterDevsUnitTests.Commands
{
    public interface ICalculatePersonalAllowanceCommand
    {
        decimal CalculatePersonalAllowance(string taxCode);
    }

    public class CalculatePersonalAllowanceCommand : ICalculatePersonalAllowanceCommand
    {
        public decimal CalculatePersonalAllowance(string taxCode)
        {
            var numericTaxCodePart = taxCode.Substring(0, taxCode.Length - 1);
            return decimal.Parse(numericTaxCodePart) * 10;
        }
    }
}