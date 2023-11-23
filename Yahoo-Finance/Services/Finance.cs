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

    public string AddFinanceInformation(StockInfo FinanceInformation)
    {
        var message = "Default message";
        try
        {
            var data = new Yahoo_Finance.Models.Finance
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
}
