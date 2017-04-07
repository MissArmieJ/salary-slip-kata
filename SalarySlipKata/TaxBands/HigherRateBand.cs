namespace SalarySlipKata.TaxBands
{
    public class HigherRateBand : TaxRateBand
    {
        public HigherRateBand(decimal annualGrossSalary, decimal excess) : base(annualGrossSalary)
        {
            LowerLimit = 43000m;
            UpperLimit = 150000m;
            TaxRatePercentage = 0.4m;
            AnnualExcessIncome = excess;
        }
    }
}