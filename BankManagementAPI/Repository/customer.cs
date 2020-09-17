using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagement.Models;

namespace BankManagement.Repository
{
    public class customer : Icustomer
    {
        BankDBContext db;
        public customer(BankDBContext _db)
        {
            db = _db;
        }
        public List<Customer> GetDetails()
        {
           
            return db.Customers.ToList();
        }
        public Customer GetDetail(int id)
        {
            if (db != null)
            {
                return (db.Customers.Where(x => x.CustomerId == id)).FirstOrDefault();
            }
            return null;
        }
        public int AddDetail(Customer cust)
        {
            if (db != null)
            {
                db.Customers.Add(cust);
                db.SaveChanges();
                return 1;
            }

            return 0;
        }
        public int UpdateDetail(int id, Customer c)
        {
            if (db != null)
            {
                Customer val = db.Customers.Where(x => x.CustomerId == id).FirstOrDefault();
                if (val != null)
                {
                    val.AccountType = c.AccountType;
                    val.Address = c.Address;
                    val.AdharCardNo = c.AdharCardNo;
                    val.Balance = c.Balance;
                    val.DOB = c.DOB;
                    val.Email = c.Email;
                    val.Name = c.Name;
                    val.PhoneNo = c.PhoneNo;
                    db.SaveChanges();
                    return 1;
                }
            }
            return 0;
        }
        public int DeleteDetail(int id)
        {
            int result = 0;

            if (db != null)
            {

                var post = db.Customers.FirstOrDefault(x => x.CustomerId == id);

                if (post != null)
                {

                    db.Customers.Remove(post);
                    result = db.SaveChanges();
                    return 1;
                }
                return result;
            }

            return result;
        }
    }
}
