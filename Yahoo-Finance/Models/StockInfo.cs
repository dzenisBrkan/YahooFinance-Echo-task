using Newtonsoft.Json;

namespace Yahoo_Finance.Models;

public class StockInfo
{
    public Data data { get; set; }
    public string message { get; set; }
    public int status { get; set; }
}

public class Data
{
    [JsonProperty("52WeekChange")]
    public double _52WeekChange { get; set; }
    public double SandP52WeekChange { get; set; }
    public string address1 { get; set; }
    public int ask { get; set; }
    public int askSize { get; set; }
    public int auditRisk { get; set; }
    public int averageDailyVolume10Day { get; set; }
    public int averageVolume { get; set; }
    public int averageVolume10days { get; set; }
    public double beta { get; set; }
    public int bid { get; set; }
    public int bidSize { get; set; }
    public int boardRisk { get; set; }
    public double bookValue { get; set; }
    public string city { get; set; }
    public List<CompanyOfficer> companyOfficers { get; set; }
    public int compensationAsOfEpochDate { get; set; }
    public int compensationRisk { get; set; }
    public string country { get; set; }
    public string currency { get; set; }
    public double currentPrice { get; set; }
    public double currentRatio { get; set; }
    public int dateShortInterest { get; set; }
    public double dayHigh { get; set; }
    public double dayLow { get; set; }
    public double debtToEquity { get; set; }
    public double dividendRate { get; set; }
    public double dividendYield { get; set; }
    public double earningsGrowth { get; set; }
    public double earningsQuarterlyGrowth { get; set; }
    public long ebitda { get; set; }
    public double ebitdaMargins { get; set; }
    public double enterpriseToEbitda { get; set; }
    public double enterpriseToRevenue { get; set; }
    public long enterpriseValue { get; set; }
    public int exDividendDate { get; set; }
    public string exchange { get; set; }
    public double fiftyDayAverage { get; set; }
    public double fiftyTwoWeekHigh { get; set; }
    public double fiftyTwoWeekLow { get; set; }
    public string financialCurrency { get; set; }
    public int firstTradeDateEpochUtc { get; set; }
    public double fiveYearAvgDividendYield { get; set; }
    public long floatShares { get; set; }
    public double forwardEps { get; set; }
    public double forwardPE { get; set; }
    public long freeCashflow { get; set; }
    public int fullTimeEmployees { get; set; }
    public int gmtOffSetMilliseconds { get; set; }
    public int governanceEpochDate { get; set; }
    public double grossMargins { get; set; }
    public long grossProfits { get; set; }
    public double heldPercentInsiders { get; set; }
    public double heldPercentInstitutions { get; set; }
    public long impliedSharesOutstanding { get; set; }
    public string industry { get; set; }
    public string industryDisp { get; set; }
    public string industryKey { get; set; }
    public int lastDividendDate { get; set; }
    public double lastDividendValue { get; set; }
    public int lastFiscalYearEnd { get; set; }
    public int lastSplitDate { get; set; }
    public string lastSplitFactor { get; set; }
    public string longBusinessSummary { get; set; }
    public string longName { get; set; }
    public long marketCap { get; set; }
    public int maxAge { get; set; }
    public string messageBoardId { get; set; }
    public int mostRecentQuarter { get; set; }
    public long netIncomeToCommon { get; set; }
    public int nextFiscalYearEnd { get; set; }
    public int numberOfAnalystOpinions { get; set; }
    public double open { get; set; }
    public long operatingCashflow { get; set; }
    public double operatingMargins { get; set; }
    public int overallRisk { get; set; }
    public double payoutRatio { get; set; }
    public double pegRatio { get; set; }
    public string phone { get; set; }
    public double previousClose { get; set; }
    public int priceHint { get; set; }
    public double priceToBook { get; set; }
    public double priceToSalesTrailing12Months { get; set; }
    public double profitMargins { get; set; }
    public double quickRatio { get; set; }
    public string quoteType { get; set; }
    public string recommendationKey { get; set; }
    public double recommendationMean { get; set; }
    public double regularMarketDayHigh { get; set; }
    public double regularMarketDayLow { get; set; }
    public double regularMarketOpen { get; set; }
    public double regularMarketPreviousClose { get; set; }
    public int regularMarketVolume { get; set; }
    public double returnOnAssets { get; set; }
    public double returnOnEquity { get; set; }
    public double revenueGrowth { get; set; }
    public double revenuePerShare { get; set; }
    public string sector { get; set; }
    public string sectorDisp { get; set; }
    public string sectorKey { get; set; }
    public int shareHolderRightsRisk { get; set; }
    public long sharesOutstanding { get; set; }
    public double sharesPercentSharesOut { get; set; }
    public int sharesShort { get; set; }
    public int sharesShortPreviousMonthDate { get; set; }
    public int sharesShortPriorMonth { get; set; }
    public string shortName { get; set; }
    public double shortPercentOfFloat { get; set; }
    public double shortRatio { get; set; }
    public string state { get; set; }
    public string symbol { get; set; }
    public double targetHighPrice { get; set; }
    public double targetLowPrice { get; set; }
    public double targetMeanPrice { get; set; }
    public double targetMedianPrice { get; set; }
    public string timeZoneFullName { get; set; }
    public string timeZoneShortName { get; set; }
    public long totalCash { get; set; }
    public double totalCashPerShare { get; set; }
    public long totalDebt { get; set; }
    public long totalRevenue { get; set; }
    public double trailingAnnualDividendRate { get; set; }
    public double trailingAnnualDividendYield { get; set; }
    public double trailingEps { get; set; }
    public double trailingPE { get; set; }
    public double trailingPegRatio { get; set; }
    public double twoHundredDayAverage { get; set; }
    public string underlyingSymbol { get; set; }
    public string uuid { get; set; }
    public int volume { get; set; }
    public string website { get; set; }
    public string zip { get; set; }
}

public class CompanyOfficer
{
    public int age { get; set; }
    public int exercisedValue { get; set; }
    public int fiscalYear { get; set; }
    public int maxAge { get; set; }
    public string name { get; set; }
    public string title { get; set; }
    public int totalPay { get; set; }
    public int unexercisedValue { get; set; }
    public int yearBorn { get; set; }
}