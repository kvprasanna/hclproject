using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MortgageCalculator.Dto;
namespace MortgageCalculator.Web.Models
{
    public class DisplayModel
    {
        [Display(Name = "TotalPurchaseAmount")]
        public decimal PurchasePrice { get; set; }
        public decimal InterestRate { get; set; }
        public double LoanTermYears { get; set; }
        public IEnumerable<Mortgage> Mortgages { get; set; }
    }
}

