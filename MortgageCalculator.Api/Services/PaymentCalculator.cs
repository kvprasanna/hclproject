using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MortgageCalculator.Api.Services
{
  
    public class PaymentCalculator
    {
        private const int MonthsPerYear = 12;

        /// <summary>
        /// The total purchase price of the item being paid for.
        /// </summary>
        public decimal PurchasePrice { get; set; }

        /// <summary>
        /// The total down payment towards the item being purchased.
        /// </summary>
        public decimal DownPayment { get; set; }

        /// <summary>
        /// Gets the total loan amount. This is the purchase price less
        /// any down payment.
        /// </summary>
        public decimal LoanAmount
        {
            get { return (PurchasePrice - DownPayment); }
        }

        /// <summary>
        /// The annual interest rate to be charged on the loan
        /// </summary>
        public decimal InterestRate { get; set; }

        /// <summary>
        /// The term of the loan in months. This is the number of months
        /// that payments will be made.
        /// </summary>
        public double LoanTermMonths { get; set; }

        /// <summary>
        /// The term of the loan in years. This is the number of years
        /// that payments will be made.
        /// </summary>
        public double LoanTermYears
        {
            get { return LoanTermMonths / MonthsPerYear; }
            set { LoanTermMonths = (value * MonthsPerYear); }
        }

      /// <returns>Returns the monthly payment amount</returns>
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