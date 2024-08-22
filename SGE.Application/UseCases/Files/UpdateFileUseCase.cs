namespace SGE.Application;

public class UpdateFileUseCase(IFileRepository repo, IAuthorizationService auth, FileValidator validator)
{
    public void Execute(File file, User user)
    {
        if (!auth.IsAllowed(user, Permission.UpdateFile))
        {
            throw new AuthorizationException();
        }
        if (!validator.IsValid(file, out string message))
        {
            throw new ValidationException(message);
        }
        file.UserId = user.Id;
        file.EditionDate = DateTime.Now;
        repo.Update(file);
    }
}
