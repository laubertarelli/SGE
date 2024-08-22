namespace SGE.Application;

public class DeleteFileUseCase(IFileRepository repo, IAuthorizationService auth)
{
    public void Execute(int id, User user)
    {
        if (!auth.IsAllowed(user, Permission.DeleteFile))
        {
            throw new AuthorizationException();
        }
        repo.Delete(id);
    }
}
