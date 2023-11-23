using Microsoft.AspNetCore.Mvc;
using Yahoo_Finance.Data;
using Yahoo_Finance.Models;
using Yahoo_Finance.Services.Interface;

namespace Yahoo_Finance.Controllers;

public class FinanceController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IFinance _finance;

    public FinanceController(ApplicationDbContext context, IFinance finance)
    {
        _context = context;
        _finance = finance;
    }

    public ActionResult Index()
    {
        IEnumerable<Finance> finances = _context.Finances;
        return View(finances);
    }

    public async Task<IActionResult> Refresh()
    {
        var value = _finance.GetFinanceInformation();
        var message = _finance.AddFinanceInformation(value);

        TempData["Info"] = message;
        return RedirectToAction("Index");
    }
}
