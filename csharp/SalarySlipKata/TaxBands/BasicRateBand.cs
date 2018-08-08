namespace SalarySlipKata.TaxBands
{
    public class BasicRateBand : TaxRateBand
    {
        public BasicRateBand(decimal annualGrossSalary) : base(annualGrossSalary)
        {
            LowerLimit = 11000m;
            UpperLimit = 43000m;
            TaxRatePercentage = 0.2m;
        }
    }
}