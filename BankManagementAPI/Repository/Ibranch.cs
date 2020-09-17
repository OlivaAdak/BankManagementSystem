using BankManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Repository
{
    public interface Ibranch
    {
        List<BranchDetails> GetDetails();
        BranchDetails GetDetail(int id);
        int AddDetail(BranchDetails data);
        int DeleteDetail(int id);
        int UpdateDetail(int id, BranchDetails obj);
    }
}
