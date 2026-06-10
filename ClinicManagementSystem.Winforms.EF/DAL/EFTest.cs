using DAL.Models;
using System.Linq;

public class EFTest
{
    public static int CountEmployees()
    {
        using var db = new CMSDbContext();

        return db.Employees.Count();
    }
}