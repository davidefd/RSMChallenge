using System.ComponentModel.DataAnnotations.Schema;

public class SalesPersonModel 
{
    public int BusinessEntityID {get;set;}
    public int TerritoryID {get; set;}
    
    [Column("SalesQuota")]
    public decimal? SP_Sales_Quota {get;set;}
    public decimal? Bonus {get;set;}
    public decimal? CommissionPct {get;set;}
    
    [Column("SalesYTD")]
    public decimal? SP_SalesYTD {get; set;}
    [Column("SalesLastYear")]
    public decimal? SP_SalesLastYear {get; set;}
}