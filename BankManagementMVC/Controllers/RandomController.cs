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
    public class RandomController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44343/api");
        HttpClient client;

        public RandomController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;

        }
        public IActionResult Index()
        {
            List<CustomerMVC> ls = new List<CustomerMVC>();

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Customer_Details").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                ls = JsonConvert.DeserializeObject<List<CustomerMVC>>(data);
            }
            return View(ls);
            
        }
        public ActionResult Create1()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create1(CustomerMVC mvc)
        {
            string data = JsonConvert.SerializeObject(mvc);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/Customer_Details", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return BadRequest();
        }
    }
}
