namespace SGE.Application
{
    public class CountProceduresByFileIdUseCase(IProcedureRepository repo)
    {
        public int Execute(int fileId) => repo.CountByFileId(fileId);
    }
}
