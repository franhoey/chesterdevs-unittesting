namespace ChesterDevsUnitTests.Commands
{
    public class CalculateTaxCommand
    {
        private readonly ICalculatePersonalAllowanceCommand _personalAllowanceCalculator;

        public CalculateTaxCommand()
            : this(new CalculatePersonalAllowanceCommand())
        {
        }

        public CalculateTaxCommand(ICalculatePersonalAllowanceCommand personalAllowanceCalculator)
        {
            _personalAllowanceCalculator = personalAllowanceCalculator;
        }

        public decimal CalculateTax(string taxCode, decimal income)
        {
            var allowance = _personalAllowanceCalculator.CalculatePersonalAllowance(taxCode);
            var taxableIncome = income > allowance ? income - allowance : 0;
            decimal tax = 0;

            // Lower threshold
            if (taxableIncome > 37500)
                tax = 37500 * 0.2m;
            else
                tax = taxableIncome * 0.2m;

            // Higher threshold
            if (taxableIncome > 150000.00m)
                tax += (150000 - 37500) * 0.4m;
            else if (taxableIncome > 37500)
                tax += (taxableIncome - 37500) * 0.4m;

            // Upper threshold
            if (taxableIncome > 150000.00m)
                tax += (taxableIncome - 150000) * 0.45m;

            return tax;
        }

        
    }
}