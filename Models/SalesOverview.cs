public class SalesOverview
{
    //This class is used to return a list of a generic object of all the table in the data base
    //PersonModel
    public int BusinessEntityID { get; set; }
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public string? JobTitle { get; set; }
    
    //SalesPersonModel
    public decimal? SP_Sales_Quota { get; set; }
    public decimal? Bonus { get; set; }
    public decimal? CommissionPct { get; set; }
    public decimal? SP_SalesYTD { get; set; }
    public decimal? SP_SalesLastYear { get; set; }
    
    //SalesQuotaHistory
    public decimal? SQH_SalesQuota { get; set; }
    public DateTime? QuotaDate { get; set; }

    //SalesTerritory
    public string? Name {get; set; }
    public string? Group {get; set; }
    public decimal? ST_SalesYTD { get; set; }
    public decimal? ST_SalesLastYear { get; set; }
    public decimal? CostYTD { get; set; }
    public decimal? CostLastYear { get; set; }

    //SalesTerritoryHistory
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

}