using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Composite.Models;
using System.Xml;
using Composite.Core;

namespace Composite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(AppSettings.MenuFile);
            List<Menu> menus = new List<Menu>();

            foreach(XmlNode nodeOuter in doc.DocumentElement.ChildNodes)
            {
                Menu menu = new Menu();
                menu.Text = nodeOuter.ChildNodes[0].InnerText;
                menu.NavigationUrl = nodeOuter.ChildNodes[1].InnerText;
                menu.OpenInWindow = bool.Parse(nodeOuter.Attributes["newwindow"].Value);

                foreach(XmlNode nodeInner in nodeOuter.ChildNodes[2].ChildNodes)
                {
                    MenuComponent menuItem = new MenuComponent();
                    menuItem.Text = nodeInner.ChildNodes[0].InnerText;
                    menuItem.NavigationUrl = nodeInner.ChildNodes[1].InnerText;
                    menu.Children.Add(menuItem);
                }
                menus.Add(menu);
            }

            return View(menus);
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
