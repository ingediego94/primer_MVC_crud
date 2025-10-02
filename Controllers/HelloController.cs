using Microsoft.AspNetCore.Mvc;

namespace inicio_Mvc_Csharp.Controllers;

public class HelloController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}