namespace SGE.Application;

public class UpdateProcedureUseCase(IProcedureRepository repo, IAuthorizationService auth, ProcedureValidator validator, IUpdateStateService updateStateService)
{
    public void Execute(Procedure procedure, User user)
    {
        if (!auth.IsAllowed(user, Permission.UpdateProcedure))
        {
            throw new AuthorizationException();
        }
        if (!validator.IsValid(procedure, out string message))
        {
            throw new ValidationException(message);
        }
        procedure.UserId = user.Id;
        procedure.EditionDate = DateTime.Now;
        repo.Update(procedure);
        updateStateService.UpdateState(procedure.FileId);
    }
}
