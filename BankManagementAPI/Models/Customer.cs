using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        
        public string Name { get; set; }
        
        public string Address{get;set;}            
        
        public DateTime DOB { get; set; }
        
        public string AdharCardNo { get; set; }
        
        public string PhoneNo { get; set; }
       
        public string Email { get; set; }
       
        public string AccountType { get; set; }
        
        public int Balance { get; set; }
    }
}
