namespace SGE.Application;
public class CountAllProceduresUseCase(IProcedureRepository repo)
{
    public int Execute() => repo.CountAll();
}
