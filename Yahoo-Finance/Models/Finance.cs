using System.ComponentModel.DataAnnotations;

namespace Yahoo_Finance.Models;

public class Finance
{
    [Key]
    public int Id { get; set; }
    public string CompanyName { get; set; }
    public string MarketCap { get; set; }
    public int YearFounded { get; set; }
    public int Employees { get; set; } //number of employees
    public string City { get; set; } //headquarters
    public string State { get; set; }
    public DateTime DateAndTime { get; set; } = DateTime.Now;
    public int PreviusClosePrice { get; set; }
    public int OpenPrice { get; set; }
}