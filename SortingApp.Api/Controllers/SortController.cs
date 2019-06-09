using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SortingApp.Api.Models;
using SortingApp.Api.Service;

namespace SortingApp.Api.Controllers
{
    [RoutePrefix("api/Sort")]
    public class SortController : ApiController
    {
        private readonly ISortProcess _sortProcess;

        public SortController()
        {
            _sortProcess = new SortProcess();
        }


        [Route("GetOrderedCustomerDetails")]
        [HttpPost]
        public IHttpActionResult GetOrderedCustomerDetails(List<Customer> customers, SortBy sortBy)
        {
            return Ok(_sortProcess.SortAndOrderCustomers(customers, sortBy));
        }

    }
}
