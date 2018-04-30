using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using MortgageCalculator.Api.Services;

namespace MortgageCalculator.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MortgageController : ApiController
    {
        // GET: api/Mortgage
        public IEnumerable<Dto.Mortgage> Get()
        {
           var mortgageService = new MortgageService();
            return mortgageService.GetAllMortgages().OrderBy(x => x.MortgageType).ThenBy(x => x.InterestRate);
        }

        // GET: api/Mortgage/5
        public Dto.Mortgage Get(int id)
        {
            var mortgageService = new MortgageService();
            return mortgageService.GetAllMortgages().FirstOrDefault(x => x.MortgageId == id);
        }
        [HttpGet]
        //GET: api/LoanPayment
        [Route("api/LoanPayment/{purchaseprice}/{interestRate}/{loanyears}")]
        public decimal LoanPayment(decimal purchaseprice, decimal interestRate, double loanyears)
        {
            var pCalculator = new PaymentCalculator
            {
                PurchasePrice = purchaseprice,
                InterestRate = interestRate,
                LoanTermYears = loanyears
            };
            return pCalculator.CalculatePayment();
        }
    }
}
