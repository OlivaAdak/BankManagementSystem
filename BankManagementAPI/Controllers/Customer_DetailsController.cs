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
    public class Customer_DetailsController : ControllerBase
    {
        readonly log4net.ILog _log4net;
        Icustomer custdata;

        public Customer_DetailsController(Icustomer _custdata)
        {
            _log4net = log4net.LogManager.GetLogger(typeof(Customer_DetailsController));
            custdata = _custdata;
            //_con = con;
        }

        //GET: api/<CustDetailsController>
        [HttpGet]
        public IActionResult GetDetails()
        {
            _log4net.Info(" Http GET request For Customer Details");
            try
            {
                var obj = custdata.GetDetails();
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
       

        // GET api/<CustDetailsController>/5
        [HttpGet("{id}")]
        
        public IActionResult GetDetail(int Id)
        {
            if (Id <= 0)
            {
                return BadRequest();
            }

            try
            {
                var data = custdata.GetDetail(Id);
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

        // POST api/<CustDetailsController>
        [HttpPost]
       
        public IActionResult AddDetail(Customer model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var Id = custdata.AddDetail(model);
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

        // PUT api/<CustDetailsController>/5
        [HttpPut("{id}")]
        
        public string UpdateDetail(int id, Customer c)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = custdata.UpdateDetail(id, c);

                    return result.ToString();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName ==
                             "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return "Updated";
                    }

                    return "cathing";
                }
            }

            return "if failed";
        }

        // DELETE api/<CustDetailsController>/5
        [HttpDelete("{id}")]
        
        public IActionResult DeleteDetail(int id)
        {


            if (id == 0)
            {
                return BadRequest(id);
            }

            try
            {
                var result = custdata.DeleteDetail(id);
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
