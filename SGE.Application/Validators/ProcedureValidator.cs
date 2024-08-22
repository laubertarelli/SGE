namespace SGE.Application;

public class ProcedureValidator
{
    public bool IsValid(Procedure procedure, out string message)
    {
        message = "";
        if (string.IsNullOrWhiteSpace(procedure.Content))
        {
            message = "Content cannot be empty";
        }
        return message == "";
    }
}
