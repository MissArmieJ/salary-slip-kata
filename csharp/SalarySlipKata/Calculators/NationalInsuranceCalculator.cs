using System.Collections.Generic;
using SalarySlipKata.NationalInsurance;

namespace SalarySlipKata.Calculators
{
    public class NationalInsuranceCalculator
    {
        private readonly decimal _annualGrossSalary;

        public NationalInsuranceCalculator(decimal annualGrossSalary)
        {
            _annualGrossSalary = annualGrossSalary;
        }

        public IEnumerable<Contribution> GetContributions()
        {
            return new List<Contribution>()
            {
                new BasicContribution(_annualGrossSalary),
                new HighContribution(_annualGrossSalary),
            };
        }
    }
}