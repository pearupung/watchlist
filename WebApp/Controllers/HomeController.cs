using System;
using System.Diagnostics;
using System.Linq;
using DAL;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using WebApp.Hubs;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        private readonly IHubContext<InstructorListHub> _hubContext;

        public HomeController(ILogger<HomeController> logger, AppDbContext context, IHubContext<InstructorListHub> hubContext)
        {
            _logger = logger;
            _context = context;
            _hubContext = hubContext;
        }

        [BindProperty]
        public HomeIndexDTO HomeIndexDto { get; set; } = new HomeIndexDTO();

        public IActionResult Index()
        {
            HomeIndexDto.Instructors = _context.Instructors.Select(i => new InstructorDTO()
            {
                InstructorName = i.InstructorName,
                RegisterCode = i.RegisterCode
            }).ToList();
            return View(HomeIndexDto);
        }

        [HttpPost]
        public IActionResult Index(HomeIndexDTO homeIndexDto)
        {
            if (!ModelState.IsValid)
            {
                return View(homeIndexDto);
            }
            var random = new Random();
            var newInstructor = new Instructor();
            newInstructor.InstructorName = HomeIndexDto.InstructorName;
            newInstructor.Active = true;
            newInstructor.RegisterCode = $"{random.Next(0, 10000):D4}";
            _context.Instructors.Add(newInstructor);
            _context.SaveChanges();
            _hubContext.Clients.All.SendAsync("NewInstructor", newInstructor);
            return Redirect("/Home/InstructorCode");
        }

        public IActionResult InstructorCode()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult InstructorCode(HomeInstructorDTO dto)
        {
            _userManager.
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}