using System.Linq;
using SalarySlipKata.Calculators;
using SalarySlipKata.Extensions;

namespace SalarySlipKata.Facades
{
    public class MonthlyCalculations
    {
        public decimal GrossSalary { get; set; }
        public decimal NationalInsurance { get; set; }
        public decimal TaxfreeAllowance { get; set; }
        public decimal TaxableIncome { get; set; }
        public decimal TaxPayable { get; set; }

        public MonthlyCalculations(decimal annualGrossSalary)
        {
            var niCalculator = new NationalInsuranceCalculator(annualGrossSalary);
            var taxCalculator = new TaxCalculator(annualGrossSalary);

            GrossSalary = annualGrossSalary.MonthlyAmount().RoundTwoDecimals();

            NationalInsurance =
                niCalculator.GetContributions().Sum(c => c.Calculate()).MonthlyAmount().RoundTwoDecimals();

            TaxfreeAllowance = taxCalculator.PersonalAllowance().MonthlyAmount().RoundTwoDecimals();
            TaxableIncome = taxCalculator.TaxableIncome().MonthlyAmount().RoundTwoDecimals();
            TaxPayable = taxCalculator.TaxBands().Sum(t => t.TaxPayable()).MonthlyAmount().RoundTwoDecimals();
        }

    }
}