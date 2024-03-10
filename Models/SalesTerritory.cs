using System.ComponentModel.DataAnnotations.Schema;

public class SalesTerritory 
{
    [Column("TerritoryID")]
    public int Territory_ID { get; set; }
    public string? Name {get; set; }
    public string? Group {get; set; }
    
    [Column("SalesYTD")]
    public decimal? ST_SalesYTD { get; set; }
    
    [Column("SalesLastYear")]
    public decimal? ST_SalesLastYear { get; set; }
    public decimal? CostYTD { get; set; }
    public decimal? CostLastYear { get; set; }
    
}