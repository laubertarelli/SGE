namespace SGE.Application;

public class GetProceduresByLabelUseCase(IProcedureRepository repo)
{
    public List<Procedure> Execute(ProcedureLabel label, int page) => repo.GetByLabel(label, page);
}
