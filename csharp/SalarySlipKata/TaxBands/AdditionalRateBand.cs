namespace SalarySlipKata.TaxBands
{
    public class AdditionalRateBand : TaxRateBand
    {
        public AdditionalRateBand(decimal annualGrossSalary) : base(annualGrossSalary)
        {
            LowerLimit = 150000m;
            UpperLimit = 0; //none
            TaxRatePercentage = 0.45m;
        }
    }
}