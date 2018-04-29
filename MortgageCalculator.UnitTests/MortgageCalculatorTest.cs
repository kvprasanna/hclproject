using System;
using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using MortgageCalculator.Api.Repos;
using MortgageCalculator.Api.Services;
using MortgageCalculator.Dto;
namespace MortgageCalculator.UnitTests
{
    [TestFixture]
    public class MortgageCalculatorTest
    {
        [Test]
        public void GetMortgageShouldReturnFromRepository()
        {
            var mockRepo = new Mock<IMortgageRepo>();
            var fakemortagedata = new List<Mortgage> {new Mortgage
            {
                CancellationFee = (decimal) 259.99,
                EffectiveEndDate = DateTime.UtcNow,
                EffectiveStartDate = DateTime.UtcNow,
                EstablishmentFee = (decimal)259.99,
                InterestRepayment =(InterestRepayment)Enum.Parse(typeof(InterestRepayment), "InterestOnly") ,
                MortgageId = 1,
                MortgageType = (MortgageType)Enum.Parse(typeof(MortgageType), "Fixed"),
                Name = "Fixed Home Loan (Interest Only)",
                TermsInMonths = 12
                
            } };
            mockRepo.Setup(x => x.GetAllMortgages()).Returns(fakemortagedata);
            var msMortgageService = new MortgageService(mockRepo.Object);

            //Act            
            var response = msMortgageService.GetAllMortgages();

            //Assert
            Assert.AreEqual(fakemortagedata,response);

        }

        [Test]
        public void PaymentCalculatorTest()
        {
            const decimal compareamount = (decimal)833.33; 
            var paymentcalc = new PaymentCalculator();
            paymentcalc.PurchasePrice = 50000;
            paymentcalc.InterestRate = (decimal) 6.0;
            paymentcalc.LoanTermYears = 5;

            var acutalCalculatePayment =  paymentcalc.CalculatePayment();
            Assert.AreEqual(acutalCalculatePayment, compareamount);
        }
    }
}
