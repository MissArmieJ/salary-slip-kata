namespace SalarySlipKata.Entities
{
    public class SalarySlip
    {
        public SalarySlip(int employeeId, string employeeName, decimal monthlyGrossSalary, decimal nationalInsurance, decimal taxfreeAllowance, decimal taxableIncome, decimal taxPayable) 
        {
            this.EmployeeId = employeeId;
            this.EmployeeName = employeeName;
            this.MonthlyGrossSalary = monthlyGrossSalary;
            this.NationalInsurance = nationalInsurance;
            this.TaxfreeAllowance = taxfreeAllowance;
            this.TaxableIncome = taxableIncome;
            this.TaxPayable = taxPayable;
        }


        public int EmployeeId { get; }
        public string EmployeeName { get; }

        public decimal MonthlyGrossSalary { get; }
        public decimal NationalInsurance { get; }

        public decimal TaxfreeAllowance { get; }
        public decimal TaxableIncome { get; }
        public decimal TaxPayable { get; }
    }
}