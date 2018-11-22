using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using emptProj.Data;
using emptProj.Services;
using emptProj.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace emptProj.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;
        private readonly EmptProjContext _context;
        public AppController(IMailService mailService, EmptProjContext context)
        {
            this._context = context;
            this._mailService = mailService;
        }
        public IActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Send email
                this._mailService.SendMessage("shawn@wildermuth.com", model.Subject, $"From: {model.Name} - {model.Email}, Message: {model.Message}");
                ViewBag.UserMessage = "Mail Sent";
                ModelState.Clear();
            }
            return View();
        }

        [HttpGet("about")]
        public IActionResult About()
        {
            ViewBag.Title = "About Us";
            return View();
        }

        public IActionResult Shop()
        {
            var results = _context.Products
                .OrderBy(p => p.Category)
                .ToList();
            
            return View();
        }
    }
}
