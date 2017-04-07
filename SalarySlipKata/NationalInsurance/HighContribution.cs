namespace SalarySlipKata.NationalInsurance
{
    public class HighContribution : Contribution
    {
        public HighContribution(decimal annualGrossSalary) : base(annualGrossSalary)
        {
            LowerLimit = 43000;
            UpperLimit = 0; //none
            ContributionPercentage = 0.02m;
        }
    }
}