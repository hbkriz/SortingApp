using System.Collections.Generic;
using System.Threading.Tasks;
using SortingApp.DTOs;

namespace SortingApp.Wrappers.SortingAppApi
{
    public interface ISortingAppApi
    {
        Task<IEnumerable<CustomerDto>> PostCustomers(IEnumerable<CustomerDto> customers, SortByDto sortBy);
    }
}