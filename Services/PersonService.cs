
public class PersonService
{
    private readonly AppDbContext _context;

    public PersonService(AppDbContext context)
    {
        _context = context;
    }

    public List<PersonModel>? GetAll()
    {
        try
        {
            List<PersonModel> personModel = _context.PersonModels.ToList();
            return personModel;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"JustError: {ex.Message}");
        }
        return null;
    }

    public List<PersonModel>? GetPersonByName(string name)
    {
        try
        {
            List<PersonModel> personModel = _context.PersonModels
                              .Where(e => (e.FirstName + " " + e.MiddleName + " " + e.LastName).Contains(name))
                              .ToList();
            return personModel;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"JustError: {ex.Message}");
        }
        return null;
    }

    public List<PersonModel>? GetPersonByPersonType(string personType)
    {
        try
        {
            List<PersonModel> personModel = _context.PersonModels
                              .Join(
                              _context.TablePersonModels,
                              a => a.BusinessEntityID, //this references BusinessEntityID in PersonModel 
                              b => b.BusinessEntityID, //this references BusinessEntityID in TablePersonModel
                              (a, b) => new { PersonModel = a, PersonPersonModel = b }
                              )
                             .Where(results => results.PersonPersonModel.PersonType == personType)
                             .Select(result => result.PersonModel)
                             .ToList();
            
            return personModel;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"JustError: {ex.Message}");
        }
        return null;
    }

    public List<PersonModel>? GetPersonByNameAndPersonType(string name, string personType)
    {
        try
        {
            var personModel = from employee in _context.PersonModels
                              join person in _context.TablePersonModels on employee.BusinessEntityID equals person.BusinessEntityID
                              where (string.IsNullOrEmpty(name) ||
                              (!string.IsNullOrEmpty(employee.FirstName) && employee.FirstName.Contains(name)) ||
                              (!string.IsNullOrEmpty(employee.MiddleName) && employee.MiddleName.Contains(name)) ||
                              (!string.IsNullOrEmpty(employee.LastName) && employee.LastName.Contains(name)))
                              && (string.IsNullOrEmpty(personType) || person.PersonType == personType)
                              select employee;

            var results = personModel.ToList();
            return results;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"JustError: {ex.Message}");
        }
        return null;
    }
}
