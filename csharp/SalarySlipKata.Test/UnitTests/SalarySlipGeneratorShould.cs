using System.Collections.Generic;
using NUnit.Framework;
using SalarySlipKata.Entities;
using SalarySlipKata.Facades;

namespace SalarySlipKata.Test.UnitTests
{
    [TestFixture]
    public class SalarySlipGeneratorShould
    {
        public static IEnumerable<TestCaseData> EmployeeTestCases
        {
            get
            {
                const int id = 12345;
                const string name = "John J Doe";

                //Iteration 1: for an annual salary of £5,000.00
                yield return new TestCaseData(
                    new Employee(id, name, annualGrossSalary: 5000),
                    new Entities.SalarySlip(id, name, monthlyGrossSalary: 416.67M, nationalInsurance: 0, taxfreeAllowance: 916.67M, taxableIncome: 0, taxPayable: 0));
                //Iteration 2: for an annual gross salary of £9,060.00
                yield return new TestCaseData(
                    new Employee(id, name, annualGrossSalary: 9060),
                    new Entities.SalarySlip(id, name, monthlyGrossSalary: 755.00M, nationalInsurance: 10.00M, taxfreeAllowance: 916.67M, taxableIncome: 0, taxPayable: 0));
                //Iteration 3: for an annual gross salary of £12,000.00
                yield return new TestCaseData(
                    new Employee(id, name, annualGrossSalary: 12000),
                    new Entities.SalarySlip(id, name, monthlyGrossSalary: 1000.00M, nationalInsurance: 39.40M, taxfreeAllowance: 916.67M, taxableIncome: 83.33M, taxPayable: 16.67M));
                //Iteration 4: for an annual gross salary of £45,000.00
                yield return new TestCaseData(
                    new Employee(id, name, annualGrossSalary: 45000),
                    new Entities.SalarySlip(id, name, monthlyGrossSalary: 3750.00M, nationalInsurance: 352.73M, taxfreeAllowance: 916.67M, taxableIncome: 2833.33M, taxPayable: 600.00M));
                //Iteration 5: for annual gross salary of £101,000.00
                yield return new TestCaseData(
                        new Employee(id, name, annualGrossSalary: 101000),
                        new Entities.SalarySlip(id, name, monthlyGrossSalary: 8416.67M, nationalInsurance: 446.07M, taxfreeAllowance: 875.00M, taxableIncome: 7541.67M, taxPayable: 2483.33M));
                //Iteration 6: for annual gross salary of £111,000.00
                yield return new TestCaseData(
                        new Employee(id, name, annualGrossSalary: 111000),
                        new Entities.SalarySlip(id, name, monthlyGrossSalary: 9250.00M, nationalInsurance: 462.73M, taxfreeAllowance: 458.33M, taxableIncome: 8791.67M, taxPayable: 2983.33M));
                //Iteration 7: for annual gross salary of £122,000.00 
                yield return new TestCaseData(
                        new Employee(id, name, annualGrossSalary: 122000),
                        new Entities.SalarySlip(id, name, monthlyGrossSalary: 10166.67M, nationalInsurance: 481.07M, taxfreeAllowance: 0.00M, taxableIncome: 10166.67M, taxPayable: 3533.33M));
                //Iteration 8: for annual gross salary of £150,000.00 
                yield return new TestCaseData(
                        new Employee(id, name, annualGrossSalary: 150000),
                        new Entities.SalarySlip(id, name, monthlyGrossSalary: 12500.00M, nationalInsurance: 527.73M, taxfreeAllowance: 0.00M, taxableIncome: 12500.00M, taxPayable: 4466.67M));
                //Iteration 9: for an annual gross salary of £160,000.00
                yield return new TestCaseData(
                        new Employee(id, name, annualGrossSalary: 160000),
                        new Entities.SalarySlip(id, name, monthlyGrossSalary: 13333.33M, nationalInsurance: 544.40M, taxfreeAllowance: 0.00M, taxableIncome: 13333.33M, taxPayable: 4841.67M));
            }
        }

        [TestCaseSource(nameof(EmployeeTestCases))]
        public void generate_a_monthly_salary_slip_for_the_employee(Employee employee, SalarySlip expectedSalarySlip)
        {
            SalarySlip salarySlip = SalarySlipGenerator.GenerateFor(employee);

            Assert.AreEqual(expectedSalarySlip.EmployeeId, salarySlip.EmployeeId);
            Assert.AreEqual(expectedSalarySlip.EmployeeName, salarySlip.EmployeeName);
            Assert.AreEqual(expectedSalarySlip.MonthlyGrossSalary, salarySlip.MonthlyGrossSalary);
            Assert.AreEqual(expectedSalarySlip.NationalInsurance, salarySlip.NationalInsurance);
            Assert.AreEqual(expectedSalarySlip.TaxfreeAllowance, salarySlip.TaxfreeAllowance);
            Assert.AreEqual(expectedSalarySlip.TaxableIncome, salarySlip.TaxableIncome);
            Assert.AreEqual(expectedSalarySlip.TaxPayable, salarySlip.TaxPayable);
        }
    }
}
