using SalarySlipKata.Extensions;

namespace SalarySlipKata.NationalInsurance
{
    public class Contribution
    {
        private readonly decimal _annualGrossSalary;

        public decimal LowerLimit { get; set; }
        public decimal UpperLimit { get; set; }
        public decimal ContributionPercentage { get; set; }

        public Contribution(decimal annualGrossSalary)
        {
            _annualGrossSalary = annualGrossSalary;
        }

        public virtual decimal Calculate()
        {
            var calculationAmount = (UpperLimit == 0 || _annualGrossSalary < UpperLimit) ? _annualGrossSalary: UpperLimit;
            var annualExcessIncome = (calculationAmount > LowerLimit) ? (calculationAmount - LowerLimit) : 0;
            var annualAmount = annualExcessIncome * ContributionPercentage;

            return annualAmount;
        }
    }
}