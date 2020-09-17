using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagement.Models;
using BankManagement.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Branch_DetailsController : ControllerBase
       
    {
       readonly log4net.ILog _log4net;
        
        Ibranch ibranch;
        public Branch_DetailsController(Ibranch _ibranch)
        {
            _log4net = log4net.LogManager.GetLogger(typeof(Branch_DetailsController));
            ibranch = _ibranch;
        }
        // GET: api/<BranchController>
        [HttpGet]
        public IActionResult GetDetails()
        {
            _log4net.Info(" Http GET request For Customer Details");
            try
            {
                var obj = ibranch.GetDetails();
                if (obj == null)
                {
                    return NotFound();
                }

                return Ok(obj);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET api/<BranchController>/5
        [HttpGet("{id}")]
        public IActionResult GetDetail(int id)
        {
            _log4net.Info("Http GET_BY_ID Request For Branch Details");
            if (id <= 0)
            {
                return BadRequest();
            }

            try
            {
                var data = ibranch.GetDetail(id);
                if (data == null)
                {
                    return NotFound();
                }
                return Ok(data);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST api/<BranchController>
        [HttpPost]
        public IActionResult AddDetail(BranchDetails details)
        {
            _log4net.Info("Http POST Request For Branch Details");
            if (ModelState.IsValid)
            {
                try
                {
                    var Id = ibranch.AddDetail(details);
                    if (Id > 0)
                    {
                        return Ok(Id);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();

        }

        // PUT api/<BranchController>/5
        [HttpPut("{id}")]
        public string UpdateDetail(int id, BranchDetails obj)
        {
            _log4net.Info("Http PUT Request For Branch Details");
            if (ModelState.IsValid)
            {
                try
                {
                    var result = ibranch.UpdateDetail(id, obj);

                    return result.ToString();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName ==
                             "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return "from catch";
                    }

                    return "from catch else";
                }

            }
            return "if failed";
        }

        // DELETE api/<BranchController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteDetail(int id)
        {
            _log4net.Info("Http DELETE Request For Branch Details");
            if (id == 0)
            {
                return BadRequest(id);
            }

            try
            {
                var result = ibranch.DeleteDetail(id);
                if (result == 0)
                {
                    return NotFound(result);
                }
                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest(id);
            }
        }
    }
}
