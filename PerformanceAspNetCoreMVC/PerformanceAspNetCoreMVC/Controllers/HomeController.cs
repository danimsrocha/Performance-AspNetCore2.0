using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PerformanceAspNetCoreMVC.Models;

namespace PerformanceAspNetCoreMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            Thread.Sleep(50000);
            var pessoas = new List<Pessoa>();
            for (int i = 0; i < 5000; i++)
            {
                pessoas.Add(new Pessoa
                {
                    Id = i,
                    Nome = "Filano " + i,
                    Email = "fulano"+ i+"@gmail.com"
                });
            }

            ViewData["Pessoa"] = pessoas;

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
