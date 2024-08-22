namespace SGE.Application;

public class GetAllProceduresUseCase(IProcedureRepository repo)
{
    public List<Procedure> Execute(int page) => repo.GetAll(page);
}
