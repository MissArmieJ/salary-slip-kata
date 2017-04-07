using System.Linq;
using NUnit.Framework;
using SalarySlipKata.Calculators;
using SalarySlipKata.Extensions;
using SalarySlipKata.TaxBands;

namespace SalarySlipKata.Test.UnitTests
{
    [TestFixture]
    public class TaxCalculatorShould
    {
        [TestCase(5000, 916.67)]
        [TestCase(100000, 916.67)]
        [TestCase(105500, 687.50)]
        [TestCase(150000, 0)]
        public void calculate_personal_allowance(decimal annualGrossSalary, decimal expectedMonthlyPersonalAllowance)
        {
            TaxCalculator calculator = new TaxCalculator(annualGrossSalary);
            var personalAllowance = calculator.PersonalAllowance();

            Assert.That(personalAllowance.MonthlyAmount().RoundTwoDecimals(), Is.EqualTo(expectedMonthlyPersonalAllowance));
        }

        [TestCase(5000, 0)]
        [TestCase(12000, 83.33)]
        [TestCase(60000, 4083.33)]
        [TestCase(130000, 10833.33)]
        public void calculate_taxable_income(decimal annualGrossSalary, decimal expectedMonthlyTaxableIncome )
        {
            TaxCalculator calculator = new TaxCalculator(annualGrossSalary);
            var taxableIncome = calculator.TaxableIncome();

            Assert.That(taxableIncome.MonthlyAmount().RoundTwoDecimals(), Is.EqualTo(expectedMonthlyTaxableIncome));
        }

        [TestCase(5000, 0)]
        [TestCase(12000, 16.67)]
        public void calculate_basic_tax_payable(decimal annualGrossSalary, decimal expectedMonthlyTaxPayable)
        {
            TaxCalculator calculator = new TaxCalculator(annualGrossSalary);
            var taxPayable = calculator.TaxBands().Sum(t => t.TaxPayable());

            Assert.That(taxPayable.MonthlyAmount().RoundTwoDecimals(), Is.EqualTo(expectedMonthlyTaxPayable));
        }

        [TestCase(45000, 533.33, 66.67)]
        [TestCase(60000, 533.33, 566.67)]
        [TestCase(105500, 533.33, 2175.00)]
        public void calculate_higher_tax_payable(decimal annualGrossSalary, decimal expectedMonthlyBasicTaxPayable, decimal expectedMonthlyHigherTaxPayable)
        {
            TaxCalculator calculator = new TaxCalculator(annualGrossSalary);
            var basicTaxPayable = calculator.TaxBands()
                .Where(t => t.GetType() == typeof(BasicRateBand))
                .Sum(t => t.TaxPayable());

            var higherTaxPayable = calculator.TaxBands()
                .Where(t => t.GetType() == typeof(HigherRateBand))
                .Sum(t => t.TaxPayable());

            Assert.That(basicTaxPayable.MonthlyAmount().RoundTwoDecimals(), Is.EqualTo(expectedMonthlyBasicTaxPayable));
            Assert.That(higherTaxPayable.MonthlyAmount().RoundTwoDecimals(), Is.EqualTo(expectedMonthlyHigherTaxPayable));
        }

        [TestCase(160000, 533.33, 3933.33, 375.00)]
        public void calculate_additional_tax_payable(decimal annualGrossSalary, 
            decimal expectedMonthlyBasicTaxPayable, 
            decimal expectedMonthlyHigherTaxPayable, 
            decimal expectedMonthlyAdditionalTaxPayable)
        {
            TaxCalculator calculator = new TaxCalculator(annualGrossSalary);
            var basicTaxPayable = calculator.TaxBands()
                .Where(t => t.GetType() == typeof(BasicRateBand))
                .Sum(t => t.TaxPayable());

            var higherTaxPayable = calculator.TaxBands()
                .Where(t => t.GetType() == typeof(HigherRateBand))
                .Sum(t => t.TaxPayable());

            var additionalTaxPayable = calculator.TaxBands()
                .Where(t => t.GetType() == typeof(AdditionalRateBand))
                .Sum(t => t.TaxPayable());

            Assert.That(basicTaxPayable.MonthlyAmount().RoundTwoDecimals(), Is.EqualTo(expectedMonthlyBasicTaxPayable));
            Assert.That(higherTaxPayable.MonthlyAmount().RoundTwoDecimals(), Is.EqualTo(expectedMonthlyHigherTaxPayable));
            Assert.That(additionalTaxPayable.MonthlyAmount().RoundTwoDecimals(), Is.EqualTo(expectedMonthlyAdditionalTaxPayable));
        }
    }
}
