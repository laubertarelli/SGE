using Microsoft.EntityFrameworkCore;
using SGE.Application;
namespace SGE.Repositories;

public class ProcedureRepository(FmsContext context) : IProcedureRepository
{
    public void Add(Procedure procedure)
    {
        context.Procedures.Add(procedure);
        context.SaveChanges();
    }

    public void Delete(int id)
    {
        Procedure procedure = context.Procedures.Where(p => p.Id == id).Single();
        context.Procedures.Remove(procedure);
        context.SaveChanges();
    }

    public void Update(Procedure procedure)
    {
        context.Procedures.Update(procedure);
        context.SaveChanges();
    }

    public List<Procedure> GetAll(int page) => context.Procedures.Include("LastEditor").Skip((page - 1) * 5).Take(5).ToList();
    public int CountAll() => context.Procedures.Count();
    public int CountByLabel(ProcedureLabel label) => context.Procedures.Where(p => p.Label == label).Count();
    public int CountByFileId(int fileId) => context.Procedures.Where(p => p.FileId == fileId).Count();
    public List<Procedure> GetByLabel(ProcedureLabel label, int page) => context.Procedures.Include("LastEditor").Where(p => p.Label == label).Skip((page - 1) * 5).Take(5).ToList();
    public Procedure? GetById(int id) => context.Procedures.Include("LastEditor").Where(p => p.Id == id).SingleOrDefault();
    public List<Procedure> GetByFileId(int fileId, int page) => context.Procedures.Include("LastEditor").Where(p => p.FileId == fileId).Skip((page - 1) * 5).Take(5).ToList();

}
