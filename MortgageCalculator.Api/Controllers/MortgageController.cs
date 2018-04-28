using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MortgageCalculator.Api.Services;

namespace MortgageCalculator.Api.Controllers
{
    public class MortgageController : ApiController
    {
        // GET: api/Mortgage
        public IEnumerable<Dto.Mortgage> Get()
        {
           var mortgageService = new MortgageService();
            return mortgageService.GetAllMortgages();
        }

        // GET: api/Mortgage/5
        public Dto.Mortgage Get(int id)
        {
            var mortgageService = new MortgageService();
            return mortgageService.GetAllMortgages().FirstOrDefault(x => x.MortgageId == id);
        }
        [HttpGet]
        //GET: api/Mortgage/LoanPayment
        [Route("api/LoanPayment/{purchaseprice}/{interestRate}/{loanyears}")]
        public decimal LoanPayment(decimal purchaseprice, decimal interestRate, double loanyears)
        {
            var pCalculator = new PaymentCalculator();
            pCalculator.PurchasePrice = purchaseprice;
            pCalculator.InterestRate = interestRate;
            pCalculator.LoanTermYears = loanyears;
            return pCalculator.CalculatePayment();
        }
    }
}
