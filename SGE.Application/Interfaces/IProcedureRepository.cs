namespace SGE.Application;

public interface IProcedureRepository
{
    public void Add(Procedure procedure);
    public void Delete(int id);
    public void Update(Procedure procedure);
    public List<Procedure> GetAll(int page);
    public int CountAll();
    public int CountByLabel(ProcedureLabel label);
    public int CountByFileId(int fileId);
    public List<Procedure> GetByLabel(ProcedureLabel label, int page);
    public Procedure? GetById(int id);
    public List<Procedure> GetByFileId(int fileId, int page);
}
