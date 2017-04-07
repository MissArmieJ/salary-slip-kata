using SalarySlipKata.Entities;

namespace SalarySlipKata.Facades
{
    public static class SalarySlipGenerator
    {
        public static SalarySlip GenerateFor(Employee employee)
        {
            var monthlyCalculations = new MonthlyCalculations(employee.AnnualGrossSalary);

            var salarySlip = new SalarySlip(
                employeeId: employee.Id,
                employeeName: employee.Name,
                monthlyGrossSalary: monthlyCalculations.GrossSalary,
                nationalInsurance: monthlyCalculations.NationalInsurance,
                taxfreeAllowance: monthlyCalculations.TaxfreeAllowance,
                taxableIncome: monthlyCalculations.TaxableIncome,
                taxPayable: monthlyCalculations.TaxPayable
                );

            return salarySlip;
        }

    }
}