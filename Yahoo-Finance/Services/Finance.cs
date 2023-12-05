using Newtonsoft.Json;
using RestSharp;
using Yahoo_Finance.Data;
using Yahoo_Finance.Models;
using Yahoo_Finance.Services.Interface;

namespace Yahoo_Finance.Services;

public class Finance : IFinance
{
    private readonly ApplicationDbContext _context;

    public Finance(ApplicationDbContext context)
    {
        _context = context;
    }

    public FinanceApiSettings FinanceApiInitializationData()
    {
        return new FinanceApiSettings
        {
            client = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("YahooFinanceAPI")["client"],
            key = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("YahooFinanceAPI")["X-RapidAPI-Key"],
            host = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("YahooFinanceAPI")["X-RapidAPI-Host"],
            contentType = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("YahooFinanceAPI")["Content-Type"]
        };
    }

    public StockInfo GetFinanceInformation()
    {
        var client = new RestClient(FinanceApiInitializationData().client);
        var request = new RestRequest("", Method.Post);
        request.AddHeader("X-RapidAPI-Key", FinanceApiInitializationData().key);
        request.AddHeader("X-RapidAPI-Host", FinanceApiInitializationData().host);
        request.AddHeader("Content-Type", FinanceApiInitializationData().contentType);
        request.AddParameter(FinanceApiInitializationData().contentType, "symbol=" + "AAPL", ParameterType.RequestBody);

        RestResponse response = client.Execute(request);

        var value = JsonConvert.DeserializeObject<StockInfo>(response.Content, new JsonSerializerSettings()
        {
            Error = (sender, error) => error.ErrorContext.Handled = true
        });
        return value;
    }


    public Root GetFinanceInformationTicker()
    {
        using (var clientNew = new HttpClient())
        {
            var endpoint = new Uri("\r\nhttps://query2.finance.yahoo.com/v1/finance/trending/US?count=5&useQuotes=true&fields=logoUrl%2CregularMarketChangePercent");
            var result = clientNew.GetAsync(endpoint).Result;
            var json = result.Content.ReadAsStringAsync().Result;
            var value = JsonConvert.DeserializeObject<Root>(json.ToString(), new JsonSerializerSettings()
            {
                Error = (sender, error) => error.ErrorContext.Handled = true
            });
            return value;
        }
    }

    public string AddFinanceInformation(StockInfo FinanceInformation)
    {
        var message = "Default message";
        try
        {
            var data = new Yahoo_Finance.Models.Finances
            {
                City = FinanceInformation.data.city,
                CompanyName = FinanceInformation.data.industry,
                DateAndTime = DateTime.Now,
                Employees = FinanceInformation.data.fullTimeEmployees,
                Id = 0,
                MarketCap = FinanceInformation.data.marketCap,
                OpenPrice = FinanceInformation.data.currentPrice,
                PreviusClosePrice = FinanceInformation.data.targetMedianPrice,
                State = FinanceInformation.data.state,
                YearFounded = FinanceInformation.data.companyOfficers.FirstOrDefault().fiscalYear,
            };
            _context.Finances.Add(data);
            _context.SaveChanges();
            message = "Data have been refreshed successfully.";
        }
        catch (Exception)
        {
            return message = "There was an eeror!";
        }
        return message;
    }

    public string AddFinanceInformationTicker(Root FinanceInformation)
    {
        var message = "Default message";
        try
        {
            foreach (var item in FinanceInformation.finance.result)
            {
                foreach (var info in item.quotes)
                {
                    var data = new Yahoo_Finance.Models.Finances
                    {
                        Ticker = info.symbol,
                        City = info.exchangeTimezoneShortName,
                        CompanyName = info.fullExchangeName,
                        DateAndTime = DateTime.Now,
                        Employees = info.sourceInterval,
                        Id = 0,
                        MarketCap = info.priceHint,
                        OpenPrice = info.regularMarketChangePercent,
                        PreviusClosePrice = info.trendingScore,
                        State = info.region,
                        YearFounded = 0000,
                    };
                    _context.Finances.Add(data);
                    _context.SaveChanges();
                }
              
            }
            message = "Data have been refreshed successfully.";
        }
        catch (Exception)
        {
            return message = "There was an eeror!";
        }

        return message;
    }
}
