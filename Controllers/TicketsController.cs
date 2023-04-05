using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace TicketTier.Controllers;

public class TicketsController : Controller
{
    // 
    // GET: /HelloWorld/
    public string Index()
    {
        return "Ready for Tickets!";
    }
}