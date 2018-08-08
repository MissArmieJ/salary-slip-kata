namespace SalarySlipKata.TaxBands
{
    public class TaxRateBand
    {
        public decimal LowerLimit { get; set; }
        public decimal UpperLimit { get; set; }
        public decimal TaxRatePercentage { get; set; }
        public decimal AnnualExcessIncome { get; set; }

        private readonly decimal _annualGrossSalary;

        public TaxRateBand(decimal annualGrossSalary)
        {
            this._annualGrossSalary = annualGrossSalary;
        }

        public decimal TaxPayable()
        {
            var calculationAmount = (UpperLimit == 0 || _annualGrossSalary < UpperLimit) ? _annualGrossSalary : UpperLimit;
            AnnualExcessIncome += (calculationAmount > LowerLimit) ? (calculationAmount - LowerLimit) : 0;
            var annualAmount = AnnualExcessIncome * TaxRatePercentage;

            return annualAmount;
        }
    }
}