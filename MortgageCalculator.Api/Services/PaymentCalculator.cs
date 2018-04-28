using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MortgageCalculator.Api.Services
{
  public class PaymentCalculator
    {
        private const int MonthsPerYear = 12;
        public decimal PurchasePrice { get; set; }
        public decimal DownPayment { get; set; }
        public decimal LoanAmount
        {
            get { return (PurchasePrice - DownPayment); }
        }
        public decimal InterestRate { get; set; }
        public double LoanTermMonths { get; set; }
        public double LoanTermYears
        {
            get { return LoanTermMonths / MonthsPerYear; }
            set { LoanTermMonths = (value * MonthsPerYear); }
        }
        public decimal CalculatePayment()
        {
            decimal payment = 0;
            decimal rate = ((InterestRate / MonthsPerYear) / 100);
            if (LoanTermMonths > 0)
            {
             payment = (LoanAmount / (decimal)LoanTermMonths);
            }
            return Math.Round(payment, 2);
        }
    }
}