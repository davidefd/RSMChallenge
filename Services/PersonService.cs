
public class PersonService
{
    private readonly AppDbContext _context;

    public PersonService(AppDbContext context)
    {
        _context = context;
    }

    public List<PersonModel>? GetAll()
    {
        var personModel = _context.PersonModels.ToList();
        return personModel;
    }

    public List<PersonModel> GetPersonByName(string name)
    {
        var personModel = _context.PersonModels
                          .Where(e => (e.FirstName + " " + e.MiddleName + " " + e.LastName).Contains(name))
                          .ToList();
        return personModel;
    }

    public List<PersonModel>? GetPersonByPersonType(string personType)
    {
        var personModel = _context.PersonModels
                          .Join(
                            _context.TablePersonModels,
                            a => a.BusinessEntityID,
                            b => b.BusinessEntityID,
                            (a, b) => new { PersonModel = a, PersonPersonModel = b }
                          )
                          .Where(results => results.PersonPersonModel.PersonType == personType)
                          .Select(result => result.PersonModel)
                          .ToList();
        return personModel;
    }

    public List<PersonModel> GetPersonByNameAndPersonType(string name, string personType)
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
}
