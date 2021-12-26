using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bridge.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Bridge.DAL.Entities;
using Bridge.DAL.Contexts;
using System.Text;
using Bridge.Core;

namespace Bridge.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDataImporter _dataImporter;
        private readonly NorthwindContext _context;

        public HomeController(ILogger<HomeController> logger, 
                                NorthwindContext context, 
                                IDataImporter dataImporter)
        {
            _logger = logger;
            this._context = context;
            this._dataImporter = dataImporter;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Upload(IList<IFormFile> files)
        {
            foreach(var file in files)
            {   
                List<Customer> records = new List<Customer>();
                StreamReader reader = new StreamReader(file.OpenReadStream());
                
                while(true)
                {
                    string record = reader.ReadLine();
                    if(string.IsNullOrEmpty(record))
                    {
                        break;
                    }
                    else
                    {
                        string [] cols = record.Split(",");
                        Customer customer = new Customer()
                        {
                            CustomerId = cols[0],
                            CompanyName = cols[1],
                            ContactName = cols[2],
                            Country = cols[3]
                        };
                        records.Add(customer);
                    }
                }
                this._dataImporter.Import(records);
            }
            ViewBag.Message = $"Data imported from {files.Count} files.\r\n Please see error log for any errors !";

            return View("Index");
        }
    }
}
