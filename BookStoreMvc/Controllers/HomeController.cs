using BookStoreMvc.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService _bookService;
        public HomeController(IBookService bookService)
        {
            _bookService = bookService;
        }
    /*    public IActionResult UserLogin(string username,string password)
        {
               
               return RedirectToAction("Index");
        }*/
        public IActionResult Index()
        {
            var books = _bookService.List();
            return View(books);
        }

        public IActionResult About()
        {
            return View();
        }

        
    }
}
