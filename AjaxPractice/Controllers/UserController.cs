using AjaxPractice.DataAccess;
using AjaxPractice.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace AjaxPractice.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationContext _context;

        public UserController(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<User> users = await _context.Users.ToListAsync();
            return View(users);
        }

        [HttpPost]
        public async Task<JsonResult> Add(string name, string surname, string email, int age)
        {
            User user = new()
            {
                Firstname = name,
                lastname = surname,
                Email = email,
                Age = age
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return Json(new
            {
                status = HttpStatusCode.OK,
                data = user
            });
        }
    }
}
