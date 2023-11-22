using Microsoft.AspNetCore.Mvc;
using Yahoo_Finance.Data;
using Yahoo_Finance.Models;
using RestSharp;
using Newtonsoft.Json;
using System;

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

    public async Task<IActionResult> Refresh()
    {
        var client = new RestClient("https://yfinance-stock-market-data.p.rapidapi.com/stock-info");

        var request = new RestRequest("", Method.Post);
        request.AddHeader("X-RapidAPI-Key", "3657dd53ebmsh5b36306629f8563p1d6081jsne82e0ca05a3d");
        request.AddHeader("X-RapidAPI-Host", "yfinance-stock-market-data.p.rapidapi.com");
        request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
        request.AddParameter("application/x-www-form-urlencoded", "symbol=" + "AAPL", ParameterType.RequestBody);

        RestResponse response = client.Execute(request);

        var value = JsonConvert.DeserializeObject<StockInfo> (response.Content, new JsonSerializerSettings()
        {
            Error = (sender, error) => error.ErrorContext.Handled = true
        });

        var data = new Finance
        {
            City = value.data.city,
            CompanyName = value.data.industry,
            DateAndTime = DateTime.Now,
            Employees = value.data.fullTimeEmployees,
            Id = 0,
            MarketCap = value.data.marketCap,
            OpenPrice = value.data.currentPrice,
            PreviusClosePrice = value.data.priceHint,
            State = value.data.state,
            YearFounded = 0
        };

        var tableData = _context.Finances.ToList();

        foreach (var item in tableData)
        {
            if (item == data)
            {
                TempData["Message"] = "Data is up to date";
                return RedirectToAction("Index");
            }
            else
            {
                _context.Finances.Add(data);
                _context.SaveChanges();
            }
        }

        return RedirectToAction("Index");
    }
}
