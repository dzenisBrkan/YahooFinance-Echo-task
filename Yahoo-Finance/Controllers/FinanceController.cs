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

    public ActionResult Index(string dateSearch, string tickerSearch)
    {
        IEnumerable<Finances> finances = _context.Finances;
        
        if (!string.IsNullOrEmpty(dateSearch) || !string.IsNullOrEmpty(tickerSearch))
        {
            if (DateTime.TryParse(dateSearch, out var dateTime))
            {
                finances = finances.Where(x => x.DateAndTime.ToString() == dateTime.ToString()).ToList();
            }
            else if (!string.IsNullOrEmpty(tickerSearch))
            {
                finances = finances.Where(x => x.Ticker == tickerSearch).ToList();
            }
        }

        return View(finances);
    }

    public async Task<IActionResult> Refresh()
    {
        var data = _finance.GetFinanceInformationTicker();
        var message = _finance.AddFinanceInformationTicker(data);
        TempData["Info"] = message;
        return RedirectToAction("Index");
    }
}
