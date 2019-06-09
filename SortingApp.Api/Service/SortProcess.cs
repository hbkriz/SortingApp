using System;
using System.Collections.Generic;
using System.Linq;
using SortingApp.Api.Models;

namespace SortingApp.Api.Service
{
    public class SortProcess : ISortProcess
    {
        public IOrderedEnumerable<Customer> SortAndOrderCustomers(List<Customer> customers, SortBy sortBy)
        {
            switch (sortBy)
            {
                case SortBy.Age:
                    return OrderByAge(customers);
                case SortBy.LastName:
                    return OrderByLastName(customers);
                case SortBy.Registered:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(sortBy), sortBy, null);
            }
            return OrderByRegistered(customers);
        }

        private static IOrderedEnumerable<Customer> OrderByAge(IEnumerable<Customer> customers)
        {
            return customers.OrderByDescending(i => i.Age);
        }

        private static IOrderedEnumerable<Customer> OrderByRegistered(IEnumerable<Customer> customers)
        {
            return customers.OrderBy(i => i.Registered.Year)
                            .ThenBy(i => i.Registered.Month)
                            .ThenBy(i => i.Registered.Date)
                            .ThenBy(i => i.Registered.TimeOfDay);
        }

        private static IOrderedEnumerable<Customer> OrderByLastName(IEnumerable<Customer> customers)
        {
            var sortedCustomer = from customer in customers
                            orderby customer.LastName
                            select customer;
            
            return sortedCustomer;
        }
    }
}