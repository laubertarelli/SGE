namespace SGE.Application
{
    public class CountProceduresByLabelUseCase(IProcedureRepository repo)
    {
        public int Execute(ProcedureLabel label) => repo.CountByLabel(label);
    }
}
