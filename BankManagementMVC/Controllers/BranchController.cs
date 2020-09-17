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
    public class BranchController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44343/api");
        HttpClient client;

        public BranchController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;

        }
        public IActionResult GetDetails()
        {
            List<BranchMVC> ls = new List<BranchMVC>();

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Branch_Details/").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                ls = JsonConvert.DeserializeObject<List<BranchMVC>>(data);
            }
            return View(ls);
        }
        public IActionResult Details(int id)
        {
            BranchMVC obj = new BranchMVC();

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Branch_Details/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                obj = JsonConvert.DeserializeObject<BranchMVC>(data);
            }

            return View(obj);
        }
            public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BranchMVC mvc)
        {
            string data = JsonConvert.SerializeObject(mvc);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync("https://localhost:44343/api/Branch_Details", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("GetDetails");
            }
            return BadRequest();
        }
        public IActionResult Edit(int id)
        {
            BranchMVC cust = new BranchMVC();


            HttpResponseMessage response = client.GetAsync("https://localhost:44343/api/Branch_Details/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                cust = JsonConvert.DeserializeObject<BranchMVC>(data);
            }

            return View(cust);
        }
        [HttpPost]
        public ActionResult Edit(BranchMVC mvc)
        {
            string data = JsonConvert.SerializeObject(mvc);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/Branch_Details/" + mvc.BranchId, content).Result;
            if (response.IsSuccessStatusCode)
                return RedirectToAction("GetDetails");
            return BadRequest();

        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/Branch_Details/" + id).Result;
            if (response.IsSuccessStatusCode)
                return RedirectToAction("GetDetails");
            return BadRequest();
        }

    }

}
