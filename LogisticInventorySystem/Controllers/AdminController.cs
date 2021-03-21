using LogisticInventorySystem.Areas.Identity.Data;
using LogisticInventorySystem.Data;
using LogisticInventorySystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<LogisticInventorySystemUser> _userManager;
        private readonly LogisticInventorySystemItemContext _context;

        public AdminController(LogisticInventorySystemItemContext context, ILogger<AdminController> logger, UserManager<LogisticInventorySystemUser> userManager)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Inventory()
        {
            return View(await _context.Item.ToListAsync());
        }

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
                ViewBag.Error = "Invalid Admin credentials.";
            }

            return View();

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .FirstOrDefaultAsync(m => m.ID == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item); 
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Item.FindAsync(id);
            _context.Item.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult StaffDirectory()
        {
            return View(_userManager.Users);
        }

    }
}
