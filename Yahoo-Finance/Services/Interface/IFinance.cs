using Yahoo_Finance.Models;

namespace Yahoo_Finance.Services.Interface;

public interface IFinance
{
    StockInfo GetFinanceInformation();
    string AddFinanceInformation(StockInfo FinanceInformation);
    public Root GetFinanceInformationTicker();
    public string AddFinanceInformationTicker(Root FinanceInformation);
}
