using NUnit.Framework;
using SalarySlipKata.Entities;
using SalarySlipKata.Facades;

namespace SalarySlipKata.Test.AcceptanceTests 
{
    [TestFixture]
    public class SalarySlipFeature
    {
        const int EmployeeId = 12345;
        const string EmployeeName = "John Doe";

        [Test]
        public void generate_salary_slip_for_employee_with_basic_case_scenario()
        {
            //Iteration 1: for an annual salary of £5,000.00
            var employee = new Employee(id:EmployeeId,name:EmployeeName,annualGrossSalary:5000);

            var salarySlip = SalarySlipGenerator.GenerateFor(employee);

            Assert.AreEqual(EmployeeId, salarySlip.EmployeeId);
            Assert.AreEqual(EmployeeName, salarySlip.EmployeeName);
            Assert.AreEqual(416.67m, salarySlip.MonthlyGrossSalary);
        }

        [Test]
        public void generate_salary_slip_for_employee_with_basic_national_insurance()
        {
            //Iteration 2: for an annual gross salary of £9,060.00
            var employee = new Employee(id: EmployeeId, name: EmployeeName, annualGrossSalary: 9060);

            var salarySlip = SalarySlipGenerator.GenerateFor(employee);

            Assert.AreEqual(EmployeeId, salarySlip.EmployeeId);
            Assert.AreEqual(EmployeeName, salarySlip.EmployeeName);
            Assert.AreEqual(755.00m, salarySlip.MonthlyGrossSalary);
            Assert.AreEqual(10.00m, salarySlip.NationalInsurance);
        }

        [Test]
        public void generate_salary_slip_for_employee_with_basic_taxes()
        {
            //Iteration 3: for an annual gross salary of £12,000.00
            var employee = new Employee(id: EmployeeId, name: EmployeeName, annualGrossSalary: 12000);

            var salarySlip = SalarySlipGenerator.GenerateFor(employee);

            Assert.AreEqual(EmployeeId, salarySlip.EmployeeId);
            Assert.AreEqual(EmployeeName, salarySlip.EmployeeName);
            Assert.AreEqual(1000.00m, salarySlip.MonthlyGrossSalary);
            Assert.AreEqual(39.40m, salarySlip.NationalInsurance);
            Assert.AreEqual(916.67m, salarySlip.TaxfreeAllowance);
            Assert.AreEqual(83.33m, salarySlip.TaxableIncome);
            Assert.AreEqual(16.67m, salarySlip.TaxPayable);
        }

        [Test]
        public void generate_salary_slip_for_employee_with_higher_ni_and_taxes()
        {
            //Iteration 4: for an annual gross salary of £45,000.00
            var employee = new Employee(id: EmployeeId, name: EmployeeName, annualGrossSalary: 45000);

            var salarySlip = SalarySlipGenerator.GenerateFor(employee);

            Assert.AreEqual(EmployeeId, salarySlip.EmployeeId);
            Assert.AreEqual(EmployeeName, salarySlip.EmployeeName);
            Assert.AreEqual(3750.00m, salarySlip.MonthlyGrossSalary);
            Assert.AreEqual(352.73m, salarySlip.NationalInsurance);
            Assert.AreEqual(916.67m, salarySlip.TaxfreeAllowance);
            Assert.AreEqual(2833.33m, salarySlip.TaxableIncome);
            Assert.AreEqual(600.00m, salarySlip.TaxPayable);
        }

        [Test]
        public void generate_salary_slip_for_employee_with_less_allowance()
        {
            //Iteration 5: for an annual gross salary of £101,000.00
            var employee = new Employee(id: EmployeeId, name: EmployeeName, annualGrossSalary: 101000);

            var salarySlip = SalarySlipGenerator.GenerateFor(employee);

            Assert.AreEqual(EmployeeId, salarySlip.EmployeeId);
            Assert.AreEqual(EmployeeName, salarySlip.EmployeeName);
            Assert.AreEqual(8416.67m, salarySlip.MonthlyGrossSalary);
            Assert.AreEqual(446.07m, salarySlip.NationalInsurance);
            Assert.AreEqual(875.00m, salarySlip.TaxfreeAllowance);
            Assert.AreEqual(7541.67m, salarySlip.TaxableIncome);
            Assert.AreEqual(2483.33m, salarySlip.TaxPayable);
        }

        [Test]
        public void generate_salary_slip_for_employee_with_additional_tax()
        {
            //Iteration 9: for an annual gross salary of £160,000.00
            var employee = new Employee(id: EmployeeId, name: EmployeeName, annualGrossSalary: 160000);

            var salarySlip = SalarySlipGenerator.GenerateFor(employee);

            Assert.AreEqual(EmployeeId, salarySlip.EmployeeId);
            Assert.AreEqual(EmployeeName, salarySlip.EmployeeName);
            Assert.AreEqual(13333.33m, salarySlip.MonthlyGrossSalary);
            Assert.AreEqual(544.40m, salarySlip.NationalInsurance);
            Assert.AreEqual(0.00m, salarySlip.TaxfreeAllowance);
            Assert.AreEqual(13333.33m, salarySlip.TaxableIncome);
            Assert.AreEqual(4841.67m, salarySlip.TaxPayable);
        }
    }
}
