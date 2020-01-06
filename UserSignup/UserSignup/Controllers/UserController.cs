using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserSignup.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserSignup.Controllers
{
    public class UserController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index(string username = "User")
        {
            ViewBag.username = username;
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(User user, string verify)
        {


            if (user != null && user.Password.Equals(verify))
            {
                return Redirect("Index?username=" + user.Username);
            }

            if (user != null)
            {
                ViewBag.username = user.Username;
                ViewBag.verify = verify;
            }

            ViewBag.error = "Please enter valid username/password";

            return View();

        }
    }
}
