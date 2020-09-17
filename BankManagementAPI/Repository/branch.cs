using BankManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Repository
{
    public class branch : Ibranch
    {
        BankDBContext db;
        public branch(BankDBContext _db)
        {
            db = _db;
        }
        public List<BranchDetails> GetDetails()
        {

            return db.Branches.ToList();
        }
        public BranchDetails GetDetail(int id)
        {
            if (db != null)
            {
                return (db.Branches.Where(x => x.BranchId == id)).FirstOrDefault();
            }
            return null;
        }
        public int AddDetail(BranchDetails details)
        {
            if (db != null)
            {
                db.Branches.Add(details);
                db.SaveChanges();
                return details.CustomerId;
            }

            return 0;
        }
        public int UpdateDetail(int id, BranchDetails obj)
        {
            if (db != null)
            {
                BranchDetails val = db.Branches.Where(x => x.BranchId == id).FirstOrDefault();
                if (val != null)
                {
                    val.CustomerId = obj.CustomerId;
                    val.Location = obj.Location;
                    val.IFSC = obj.IFSC;
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

                var post = db.Branches.FirstOrDefault(x => x.BranchId == id);

                if (post != null)
                {

                    db.Branches.Remove(post);
                    result = db.SaveChanges();
                    return 1;
                }
                return result;
            }
            return result;

        }
    }
}

