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
        private readonly IEmptProjRepository _repository;
        public AppController(IMailService mailService, IEmptProjRepository repository)
        {
            _mailService = mailService;
            _repository = repository;
        }
        public IActionResult Index()
        {
            ViewBag.Title = "Home Page";
            var results = _repository.GetAllProducts();
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
                _mailService.SendMessage("shawn@wildermuth.com", model.Subject, $"From: {model.Name} - {model.Email}, Message: {model.Message}");
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
            var results = _repository.GetAllProducts();
            
            return View(results);
        }
    }
}
