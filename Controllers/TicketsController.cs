using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace TicketTier.Controllers;

public class TicketsController : Controller
{
    // 
    // GET: /HelloWorld/
    public IActionResult Index()
    {
        return View();
    }
}