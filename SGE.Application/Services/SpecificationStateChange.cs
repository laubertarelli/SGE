namespace SGE.Application;

public class SpecificationStateChange : ISpecificationStateChange
{
    public FileState? GetState(ProcedureLabel label)
    {
        return label switch
        {
            ProcedureLabel.Resolution => FileState.Resolved,
            ProcedureLabel.InStudio => FileState.ToSolve,
            ProcedureLabel.Archived => FileState.Finished,
            _ => null,
        };
    }
}
