using System.Collections.Generic;
using System.Threading.Tasks;
using SortingApp.DTOs;
using SortingApp.Wrappers.ConfigurationManagerWrapper;
using SortingApp.Wrappers.HttpClientWrapper;

namespace SortingApp.Wrappers.SortingAppApi
{
    public class SortingAppApi: ISortingAppApi
    {
        private readonly IHttpClientWrapper _httpClientWrapper;
        public SortingAppApi(IConfigurationManagerWrapper configurationManager, IHttpClientWrapper httpClientWrapper)
        {
            _httpClientWrapper = httpClientWrapper;
            _httpClientWrapper.Initialize(configurationManager.GetAppSetting("SortingAppApiUrl"), "Sorting App Api");
        }

        public Task<IEnumerable<CustomerDto>> PostCustomers(IEnumerable<CustomerDto> customers, SortByDto sortBy)
        {
            var apiMethod = string.Format("Sort/GetOrderedCustomerDetails?sortBy={0}", sortBy);
            return _httpClientWrapper.PostAsJsonAsync<IEnumerable<CustomerDto>>(apiMethod, customers);
        }
    }
}