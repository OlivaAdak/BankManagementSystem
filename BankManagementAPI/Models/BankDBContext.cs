using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Models
{
    public class BankDBContext:DbContext
    {
        public BankDBContext(DbContextOptions<BankDBContext> options):base(options)
        {

        }
        public BankDBContext()
        {

        }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<BranchDetails> Branches { get; set; }
    }
}
