using Microsoft.AspNetCore.Mvc;

namespace TrainingAPI.Controllers;

public class DeparmentController : Controller
{
    // GET
    public IActionResult Index()
    {
        return Ok();
    }
}