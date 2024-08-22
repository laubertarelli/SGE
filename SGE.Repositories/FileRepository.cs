using Microsoft.EntityFrameworkCore;
using SGE.Application;
namespace SGE.Repositories;

public class FileRepository(FmsContext context) : IFileRepository
{
    public void Add(Application.File file)
    {
        context.Files.Add(file);
        context.SaveChanges();
    }

    public void Delete(int id)
    {
        Application.File file = context.Files.Where(f => f.Id == id).Single();
        context.Files.Remove(file);
        context.SaveChanges();
    }

    public void Update(Application.File file)
    {
        context.Files.Update(file);
        context.SaveChanges();
    }

    public Application.File? GetById(int id) => context.Files.Include("Procedures").Include("LastEditor").Where(f => f.Id == id).SingleOrDefault();
    public int CountAll() => context.Files.Count();
    public List<Application.File> GetAll(int page) => context.Files.Include("Procedures").Include("LastEditor").Skip((page - 1) * 5).Take(5).ToList();
}
