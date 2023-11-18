using Microsoft.AspNetCore.Mvc;
using Yahoo_Finance.Models;

namespace Yahoo_Finance.Controllers;

public class FinanceController : Controller
{
    public ActionResult Index()
    {
        var finane = new Finance() { CompanyName = "Echo" };
        return View(finane);
    }
}
