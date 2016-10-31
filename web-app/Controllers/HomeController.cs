using Microsoft.AspNetCore.Mvc;

namespace My.ToDoApp.WebApp
{
    public class HomeController: Controller {

        public ViewResult Index() {
            return View();
        }

        public ViewResult StandardApp() {
            return View();
        }
    }
}