namespace SGE.Application;

public class AddProcedureUseCase(IProcedureRepository repo, IAuthorizationService auth, ProcedureValidator validator, IUpdateStateService updateStateService)
{
    public void Execute(Procedure procedure, User user)
    {
        if (!auth.IsAllowed(user, Permission.AddProcedure))
        {
            throw new AuthorizationException();
        }
        if (!validator.IsValid(procedure, out string message))
        {
            throw new ValidationException(message);
        }
        procedure.UserId = user.Id;
        procedure.CreationDate = DateTime.Now;
        procedure.EditionDate = DateTime.Now;
        repo.Add(procedure);
        updateStateService.UpdateState(procedure.FileId);
    }
}
