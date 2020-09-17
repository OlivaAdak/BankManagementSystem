using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BankManagementMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BankManagementMVC.Controllers
{
    public class CustomerController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44343/api");
        HttpClient client;

        public CustomerController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;

        }
        public IActionResult GetDetails()
        {
            List<CustomerMVC> ls = new List<CustomerMVC>();

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Customer_Details/").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                ls = JsonConvert.DeserializeObject<List<CustomerMVC>>(data);
            }
            return View(ls);
        }
        public IActionResult Details(int id)
        {
            CustomerMVC obj = new CustomerMVC();

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Customer_Details/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                obj = JsonConvert.DeserializeObject<CustomerMVC>(data);
            }

            return View(obj);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CustomerMVC mvc)
        {
            string data = JsonConvert.SerializeObject(mvc);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync("https://localhost:44343/api/Customer_Details", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("GetDetails");
            }
            return BadRequest();
        }
        public IActionResult Edit(int id)
        {
            CustomerMVC cust = new CustomerMVC();
           

            HttpResponseMessage response = client.GetAsync("https://localhost:44343/api/Customer_Details/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                cust = JsonConvert.DeserializeObject<CustomerMVC>(data);
            }

            return View(cust);
        }
        [HttpPost]
        public ActionResult Edit(CustomerMVC cust)
        {
            string data = JsonConvert.SerializeObject(cust);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/Customer_Details/" + cust.CustomerId, content).Result;
            if (response.IsSuccessStatusCode)
                return RedirectToAction("GetDetails");
            return BadRequest();
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/Customer_Details/" + id).Result;
            if (response.IsSuccessStatusCode)
                return RedirectToAction("GetDetails");
            return BadRequest();
        }



    }
}
