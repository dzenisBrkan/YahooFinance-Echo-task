namespace Yahoo_Finance.Models;

public class Root
{
    public Finance finance { get; set; }
}

public class Finance
{
    public List<Result> result { get; set; }
    public object error { get; set; }
}

public class Quote
{
    public string language { get; set; }
    public string region { get; set; }
    public string quoteType { get; set; }
    public string typeDisp { get; set; }
    public string quoteSourceName { get; set; }
    public bool triggerable { get; set; }
    public string customPriceAlertConfidence { get; set; }
    public double trendingScore { get; set; }
    public object firstTradeDateMilliseconds { get; set; }
    public int priceHint { get; set; }
    public double regularMarketChangePercent { get; set; }
    public int regularMarketTime { get; set; }
    public string exchange { get; set; }
    public string market { get; set; }
    public string fullExchangeName { get; set; }
    public string marketState { get; set; }
    public int sourceInterval { get; set; }
    public int exchangeDataDelayedBy { get; set; }
    public string exchangeTimezoneName { get; set; }
    public string exchangeTimezoneShortName { get; set; }
    public int gmtOffSetMilliseconds { get; set; }
    public bool esgPopulated { get; set; }
    public bool tradeable { get; set; }
    public bool cryptoTradeable { get; set; }
    public string symbol { get; set; }
    public string companyLogoUrl { get; set; }
    public string logoUrl { get; set; }
    public string coinImageUrl { get; set; }
}

public class Result
{
    public int count { get; set; }
    public List<Quote> quotes { get; set; }
    public long jobTimestamp { get; set; }
    public long startInterval { get; set; }
}

