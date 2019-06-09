using System.Collections.Generic;
using System.Linq;
using SortingApp.Api.Models;

namespace SortingApp.Api.Service
{
    public interface ISortProcess
    {
        IOrderedEnumerable<Customer> SortAndOrderCustomers(List<Customer> customers, SortBy sortBy);
    }
}