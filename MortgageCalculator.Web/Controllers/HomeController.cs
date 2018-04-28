using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MortgageCalculator.Dto;
namespace MortgageCalculator.Web.Controllers
{
    public class HomeController : Controller
    {
        
            // GET: Mortgage details
            public async Task<ActionResult> Index()
            {
                string apiUrl = "http://localhost:49608/api/Mortgage";
                var mortgages = new List<Mortgage>();
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        mortgages = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Mortgage>>(data);
                        
                }


                }

                return View(mortgages);

            }
        
    }
}
