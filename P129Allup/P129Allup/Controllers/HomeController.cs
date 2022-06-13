using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using P129Allup.DAL;
using P129Allup.ViewModels.BasketViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P129Allup.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            //HttpContext.Session.SetString("p129", "P129 Hello Worl");

            //HttpContext.Response.Cookies.Append("p129", "P129 Hello Worl Cookie");

            string basket = HttpContext.Request.Cookies["basket"];

            List<BasketVM> basketVMs = null;

            if (basket != null)
            {
                basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            }
            else
            {
                basketVMs = new List<BasketVM>();
            }

            ViewBag.Basket = basketVMs;


            return View(await _context.Products.ToListAsync());
        }

        //public  IActionResult GetSession()
        //{
        //    string session = HttpContext.Session.GetString("p129");

        //    return Content(session);
        //}

        //public IActionResult GetCookie()
        //{
        //    string session = HttpContext.Request.Cookies["p129"];

        //    return Content(session);
        //}
    }
}
