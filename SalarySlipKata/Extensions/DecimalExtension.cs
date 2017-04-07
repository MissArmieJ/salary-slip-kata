using System;

namespace SalarySlipKata.Extensions
{
    public static class DecimalExtension
    {
        public static decimal MonthlyAmount(this decimal d)
        {
            return d/12;
        }

        public static decimal RoundTwoDecimals(this decimal d)
        {
            return Math.Round(d, 2);
        }
    }
}