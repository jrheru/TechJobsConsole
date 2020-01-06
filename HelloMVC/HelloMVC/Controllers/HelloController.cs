using Microsoft.AspNetCore.Mvc;

namespace HelloMVC.Controllers
{
    [HttpGet]
    public class HelloController : Controller
    {
        public IActionResult Index()
        {
            string html = "<form method='post'>" +
                "<input type='text' name='name'>" +
                "<select name='lang'>" +
                "<option value='en'>English</option>" +
                "<option value='fr'>French</option>" +
                "<option value='sp'>Spanish</option>" +
                "</select>" +
                "<input type='submit' value='Greet me!'>" +
                "</form>";

            return Content(html, "text/html"); ;
        }
        
        [Route("/Hello")]
        [HttpPost]
        public IActionResult Display(string lang, string name = "World")

        {
            sring greetingHtml = CreateMessage(name, lang);

            return Content(greetingHtml, "text/html");
            {
                public static string CreateMessage(string name, string langOption)
                {
                    string greeting = "";

                    switch (langOption)
                    {
                        case "en":
                            greeting = "Hello";
                            break;
                        case "fr":
                            greeting = "Bonjour";
                            break;
                        case "sp":
                            greeting = "Hola";
                            break;
                        default:
                            greeting = "Hi";
                            break;
                            {
                             return "<h1>" + greeting + " " + name + "</h1>"
                            }
                    }
                }
            }
        }
    }
}
