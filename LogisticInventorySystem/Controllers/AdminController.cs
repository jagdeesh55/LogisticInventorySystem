using LogisticInventorySystem.Data;
using LogisticInventorySystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogisticInventorySystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;

        private readonly LogisticInventorySystemItemContext _context;

        public AdminController(LogisticInventorySystemItemContext context, ILogger<AdminController> logger)
        {
            _context = context;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Inventory()
        {
            return View(await _context.Item.ToListAsync());
        }

        public ActionResult

        //[HttpPost]
        public ActionResult AdminLogin(IFormCollection collection)
        {
            string email = Convert.ToString(collection["username"]);
            string Password = Convert.ToString(collection["password"]);
            if (email == "admin1" && Password == "admin1")
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Please enter valid Email ID and Password";
            }

            return View();

        }

    }
}
