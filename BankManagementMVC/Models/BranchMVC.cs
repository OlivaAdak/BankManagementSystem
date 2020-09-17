using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementMVC.Models
{
    public class BranchMVC
    {
        public int BranchId { get; set; }
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Branch Name is Required")]
        public string Location { get; set; }
        [Required]
        [StringLength(5, MinimumLength = 5)]
        public string IFSC { get; set; }
    }
}
