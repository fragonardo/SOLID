using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Factory_Method.Models;
using Factory_Method.Core;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace Factory_Method.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private Color[] colors;
        private List<string> xdata = new List<string>();
        private List<int> ydata = new List<int>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

            xdata = new List<string>();
            xdata.Add("Mon");
            xdata.Add("Tue");
            xdata.Add("Wed");
            xdata.Add("Thu");
            xdata.Add("Fri");
            xdata.Add("Sat");
            xdata.Add("Sun");

            ydata = new List<int>();
            ydata.Add(12);
            ydata.Add(7);
            ydata.Add(4);
            ydata.Add(10);
            ydata.Add(3);
            ydata.Add(11);
            ydata.Add(5);

            Random rand = new Random();

            colors = new Color[ydata.Count];

            for(int i = 0; i<ydata.Count; i++)
            {
                colors[i] = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetImageFree()
        {
            IChartProvider provider = new ChartProviderFree();
            IChart chart = provider.GetChart();

            chart.Title = "Hours per day";

            chart.XData = xdata;
            chart.YData = ydata;
            chart.colors = colors;

            Bitmap bmp = chart.GenerateChart();
            MemoryStream stream = new MemoryStream();
            bmp.Save(stream, ImageFormat.Png);
            byte[] data = stream.ToArray();
            stream.Close();
            return File(data, "image/png");
        }

        public IActionResult GetImagePaid()
        {
            IChartProvider provider = new ChartProviderPaid();
            IChart chart = provider.GetChart();

            chart.Title = "Hours per day";
            
            chart.XData = xdata;
            chart.YData = ydata;
            chart.colors = colors;

            Bitmap bmp = chart.GenerateChart();
            MemoryStream stream = new MemoryStream();
            bmp.Save(stream, ImageFormat.Png);
            byte[] data = stream.ToArray();
            stream.Close();
            return File(data, "image/png");
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
    }
}
