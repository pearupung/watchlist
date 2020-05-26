using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public HomeIndexDTO HomeIndexDto { get; set; } = new HomeIndexDTO();

        public IActionResult Index()
        {
            HomeIndexDto.Instructors = _context.Instructors.Select(i => new InstructorDTO()
            {
                InstructorName = i.InstructorName
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

            _context.Instructors.Add(new Instructor()
            {
                InstructorName = HomeIndexDto.InstructorName
            });
            _context.SaveChanges();
            return Redirect("/Home/InstructorCode");
        }

        public IActionResult InstructorCode()
        {
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