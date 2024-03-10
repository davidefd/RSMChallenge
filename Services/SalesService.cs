public class SalesService
{
    private readonly AppDbContext _context;

    public SalesService(AppDbContext context)
    {
        _context = context;
    }

    public List<SalesOverview>? GetAll()
    {
        try
        {
            var salesModel = from person in _context.PersonModels
                             join salesPerson in _context.SalesPersonModels on person.BusinessEntityID equals salesPerson.BusinessEntityID
                             join salesQuota in _context.SalesQuotaHistoryModels on person.BusinessEntityID equals salesQuota.BusinessEntityID
                             join salesTerritory in _context.SalesTerritorys on salesPerson.TerritoryID equals salesTerritory.Territory_ID
                             join salesTHistory in _context.SalesTerritoryHistorys on salesPerson.BusinessEntityID equals salesTHistory.BusinessEntityID
                             orderby salesQuota.QuotaDate
                             select new SalesOverview
                             {
                                 BusinessEntityID = person.BusinessEntityID,
                                 FirstName = person.FirstName,
                                 MiddleName = person.MiddleName,
                                 LastName = person.LastName,
                                 JobTitle = person.JobTitle,

                                 SP_Sales_Quota = salesPerson.SP_Sales_Quota,
                                 Bonus = salesPerson.Bonus,
                                 CommissionPct = salesPerson.CommissionPct,
                                 SP_SalesYTD = salesPerson.SP_SalesYTD,
                                 SP_SalesLastYear = salesPerson.SP_SalesLastYear,

                                 SQH_SalesQuota = salesQuota.SQH_SalesQuota,
                                 QuotaDate = salesQuota.QuotaDate,

                                 Name = salesTerritory.Name,
                                 Group = salesTerritory.Group,
                                 ST_SalesYTD = salesTerritory.ST_SalesYTD,
                                 ST_SalesLastYear = salesTerritory.ST_SalesLastYear,
                                 CostYTD = salesTerritory.CostYTD,
                                 CostLastYear = salesTerritory.CostLastYear,

                                 StartDate = salesTHistory.StartDate,
                                 EndDate = salesTHistory.EndDate
                             };

            return salesModel.ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"JustError: {ex.Message}");
        }
        return null;
    }

    public List<SalesOverview>? GetBySalesByPersonAndYear(string name, int year)
    {
        try
        {
            var salesModel = from person in _context.PersonModels
                             join salesPerson in _context.SalesPersonModels on person.BusinessEntityID equals salesPerson.BusinessEntityID
                             join salesQuota in _context.SalesQuotaHistoryModels on person.BusinessEntityID equals salesQuota.BusinessEntityID
                             orderby salesQuota.QuotaDate
                             where (string.IsNullOrEmpty(name) || 
                             !string.IsNullOrEmpty(person.FirstName) && person.FirstName.Contains(name) ||
                             !string.IsNullOrEmpty(person.MiddleName) && person.MiddleName.Contains(name) ||
                             !string.IsNullOrEmpty(person.LastName) && person.LastName.Contains(name)) 
                             &&
                             salesQuota.QuotaDate.Year == year
                             
                             select new SalesOverview
                             {
                                 BusinessEntityID = person.BusinessEntityID,
                                 FirstName = person.FirstName,
                                 MiddleName = person.MiddleName,
                                 LastName = person.LastName,
                                 JobTitle = person.JobTitle,

                                 SP_Sales_Quota = salesPerson.SP_Sales_Quota,
                                 Bonus = salesPerson.Bonus,
                                 CommissionPct = salesPerson.CommissionPct,
                                 SP_SalesYTD = salesPerson.SP_SalesYTD,
                                 SP_SalesLastYear = salesPerson.SP_SalesLastYear,

                                 SQH_SalesQuota = salesQuota.SQH_SalesQuota,
                                 QuotaDate = salesQuota.QuotaDate

                             };

            return salesModel.ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"JustError: {ex.Message}");
        }
        return null;
    }
}