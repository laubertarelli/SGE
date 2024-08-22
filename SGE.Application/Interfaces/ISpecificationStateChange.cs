namespace SGE.Application;

public interface ISpecificationStateChange
{
    public FileState? GetState(ProcedureLabel label);
}
