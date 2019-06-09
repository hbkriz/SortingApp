using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using SortingApp.DTOs;
using SortingApp.Models;
using SortingApp.Wrappers.ConfigurationManagerWrapper;
using SortingApp.Wrappers.HttpClientWrapper;
using SortingApp.Wrappers.SortingAppApi;

namespace SortingApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISortingAppApi _sortingAppApi;
        public HomeController() : this(new SortingAppApi(new ConfigurationManagerWrapper(), new HttpClientWrapper()))
        {

        }

        public HomeController(ISortingAppApi sortingAppApi)
        {
            _sortingAppApi = sortingAppApi;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var payload = new Payload
            {
                Customers = new List<CustomerDto>(),
                JsonInput = string.Empty
            };
            return View(payload);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(Payload model)
        {
            if (ModelState.IsValid)
            {
                var result = JsonConvert.DeserializeObject<PayloadResponse<CustomerDto>>(model.JsonInput);
                var apiResponse = await _sortingAppApi.PostCustomers(result.Payload, model.SortBy);
                model.Customers = apiResponse.ToList();
            }
            else
            {
                model.Customers = new List<CustomerDto>();
            }


            return View(model);
        }
    }
}