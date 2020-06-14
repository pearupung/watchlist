using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
        private UserManager<AppUser> _userManager;

        public HomeController(ILogger<HomeController> logger, AppDbContext context, IHubContext<InstructorListHub> hubContext, UserManager<AppUser> userManager)
        {
            _logger = logger;
            _context = context;
            _hubContext = hubContext;
            _userManager = userManager;
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
        public async Task<IActionResult> InstructorCode(HomeInstructorDTO dto)
        {
            /*
            if (!ModelState.IsValid)
            {
                return View(dto);
            }*/
            
            return RedirectToAction("InstructorSession");
        }

        public async Task<IActionResult> InstructorSession()
        {
            var dto = new InstructorSessionDTO();
            return View(dto);
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