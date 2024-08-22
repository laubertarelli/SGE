namespace SGE.Application;

public class DeleteProcedureUseCase(IProcedureRepository repo, IAuthorizationService auth, IUpdateStateService updateStateService, GetProcedureByIdUseCase getProcedure)
{
    public void Execute(int id, User user)
    {
        if (!auth.IsAllowed(user, Permission.DeleteProcedure))
        {
            throw new AuthorizationException();
        }
        Procedure procedure = getProcedure.Execute(id);
        repo.Delete(id);
        updateStateService.UpdateState(procedure.FileId);
    }
}
