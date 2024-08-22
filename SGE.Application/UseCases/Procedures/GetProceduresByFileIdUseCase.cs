namespace SGE.Application;

public class GetProceduresByFileIdUseCase(IProcedureRepository repo)
{
    public List<Procedure> Execute(int fileId, int page) => repo.GetByFileId(fileId, page);
}
