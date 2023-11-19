using Microsoft.AspNetCore.Mvc;
using Yahoo_Finance.Data;
using Yahoo_Finance.Models;
using RestSharp;

namespace Yahoo_Finance.Controllers;

public class FinanceController : Controller
{
    private readonly ApplicationDbContext _context;

    public FinanceController(ApplicationDbContext context)
    {
        _context = context;
    }

    public ActionResult Index()
    {
        IEnumerable<Finance> finances = _context.Finances;
        return View(finances);
    }
}
