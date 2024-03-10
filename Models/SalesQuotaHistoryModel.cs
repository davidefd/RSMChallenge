using System.ComponentModel.DataAnnotations.Schema;

public class SalesQuotaHistoryModel
{

    public int BusinessEntityID { get; set; }
    public DateTime? QuotaDate { get; set; }
    
    [Column("SalesQuota")]
    public decimal? SQH_SalesQuota { get; set; }

}