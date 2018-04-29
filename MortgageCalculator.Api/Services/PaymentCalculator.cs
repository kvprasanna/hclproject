using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MortgageCalculator.Api.Services
{
    public interface IPaymentCalculator
    {
        decimal PurchasePrice { get; set; }
        decimal DownPayment { get; set; }
        decimal LoanAmount { get; set; }
        decimal InterestRate { get; set; }
        double LoanTermMonths { get; set; }
        double LoanTermYears { get; set; }
        decimal CalculatePayment();
    }
  public class PaymentCalculator: IPaymentCalculator
    {
        private const int MonthsPerYear = 12;
        public decimal PurchasePrice { get; set; }
        public decimal DownPayment { get; set; }
        public decimal LoanAmount
        {
            get { return (PurchasePrice - DownPayment); }
            set { }
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

            if (LoanTermMonths > 0)
            {
                if (InterestRate != 0)
                {
                    decimal rate = ((InterestRate / MonthsPerYear) / 100);
                    decimal factor = (rate + (rate / (decimal) (Math.Pow((double) (rate + 1), LoanTermMonths) - 1)));
                    payment = (LoanAmount * factor);
                }
                else payment = (LoanAmount / (decimal)LoanTermMonths);
            }
            return Math.Round(payment, 2);
        }
    }
}