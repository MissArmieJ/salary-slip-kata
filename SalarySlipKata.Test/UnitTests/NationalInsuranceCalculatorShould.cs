using System.Linq;
using NUnit.Framework;
using SalarySlipKata.Calculators;
using SalarySlipKata.Extensions;

namespace SalarySlipKata.Test.UnitTests
{
    [TestFixture]
    public class NationalInsuranceCalculatorShould
    {
        [TestCase(5000,0)]
        [TestCase(9060,10)]
        [TestCase(12000, 39.40)]
        [TestCase(45000, 352.73)]
        [TestCase(101000, 446.07)]
        public void calculate_contributions_for(decimal annualGrossSalary, decimal monthlyContribution)
        {
            NationalInsuranceCalculator calculator = new NationalInsuranceCalculator(annualGrossSalary);
            var contributions = calculator.GetContributions();

            Assert.That(contributions.Sum(c => c.Calculate()).MonthlyAmount().RoundTwoDecimals(), Is.EqualTo(monthlyContribution));
        }
    }
}
