namespace SGE.Application;

public class GetProcedureByIdUseCase(IProcedureRepository repo)
{
    public Procedure Execute(int id)
    {
        Procedure? procedure = repo.GetById(id);
        if (procedure is null)
        {
            throw new RepositoryException("Procedure not found");
        }
        return procedure;
    }
}
