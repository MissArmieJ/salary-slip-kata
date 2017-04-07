using System.Collections.Generic;
using SalarySlipKata.TaxBands;

namespace SalarySlipKata.Calculators
{
    public class TaxCalculator
    {
        const decimal PersonalAllowanceBenchmark = 100000M;
        const decimal BasicPersonalAllowance = 11000M;

        private readonly decimal _annualGrossSalary;

        public TaxCalculator(decimal annualGrossSalary)
        {
            _annualGrossSalary = annualGrossSalary;
        }


        public decimal PersonalAllowance()
        {
            if (_annualGrossSalary <= PersonalAllowanceBenchmark) return BasicPersonalAllowance;
            return BasicPersonalAllowance - PersonalAllowanceDeduction();

        }

        private decimal PersonalAllowanceDeduction()
        {
            if (_annualGrossSalary <= PersonalAllowanceBenchmark) return 0;
            var deduction = (_annualGrossSalary - PersonalAllowanceBenchmark) * 0.5M;
            return deduction > BasicPersonalAllowance ? BasicPersonalAllowance : deduction;
        }

        public decimal TaxableIncome()
        {
            var personalAllowance = PersonalAllowance();
            return _annualGrossSalary > personalAllowance ? (_annualGrossSalary - personalAllowance) : 0;
        }

        public IEnumerable<TaxRateBand> TaxBands()
        {
            return new List<TaxRateBand>()
            {
                new BasicRateBand(_annualGrossSalary),
                new HigherRateBand(_annualGrossSalary, PersonalAllowanceDeduction()),
                new AdditionalRateBand(_annualGrossSalary)
            };
        }
    }
}