using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SortingApp.DTOs;

namespace SortingApp.Models
{
    public class Payload
    {
        public IList<CustomerDto> Customers { get; set; }
        
        [Required(ErrorMessage="Please Enter Input")]
        [Display(Name = "Json Input")]
        public string JsonInput { get; set; }

        [Display(Name = "Sort By")]
        public SortByDto SortBy { get; set; }

    }
}