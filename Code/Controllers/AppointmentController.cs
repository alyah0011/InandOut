using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
            //string todaysDAte = DateTime.Now.ToShortDateString();
            //return Ok(todaysDAte);
        }   

        public IActionResult Details(int id) 
        {
            return Ok("You have entered id = " + id);
        }
    }
}
