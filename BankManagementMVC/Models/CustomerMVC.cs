using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementMVC.Models
{
    public class CustomerMVC
    {
        [Key]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Customer Name is required")]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Employee Address is required")]
        [StringLength(300)]
        public string Address { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        [StringLength(5, MinimumLength = 5)]
        public string AdharCardNo { get; set; }
        [Required]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string PhoneNo { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect Email Format")]
        public string Email { get; set; }
        [Required]
        public string AccountType { get; set; }
        [Required]
        [Range(5000, 10000000, ErrorMessage = "Minimumm balance must be 5000")]
        public int Balance { get; set; }
    }
}
