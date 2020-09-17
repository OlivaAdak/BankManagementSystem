using BankManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Repository
{
    public interface Icustomer
    {
        List<Customer> GetDetails();
        Customer GetDetail(int id);
        int AddDetail(Customer data);
        int DeleteDetail(int id);
        int UpdateDetail(int id, Customer c);

    }
}
