namespace SalarySlipKata.NationalInsurance
{
    public class BasicContribution : Contribution
    {

        public BasicContribution(decimal annualGrossSalary) : base(annualGrossSalary)
        {
            LowerLimit = 8060m;
            UpperLimit = 43000m;
            ContributionPercentage = 0.12m;
        }
        
    }
}