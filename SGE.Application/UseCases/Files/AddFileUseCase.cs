namespace SGE.Application;

public class AddFileUseCase(IFileRepository repo, IAuthorizationService auth, FileValidator validator)
{
    public void Execute(File file, User user)
    {
        if (!auth.IsAllowed(user, Permission.AddFile))
        {
            throw new AuthorizationException();
        }
        if (!validator.IsValid(file, out string message))
        {
            throw new ValidationException(message);
        }
        file.UserId = user.Id;
        file.CreationDate = DateTime.Now;
        file.EditionDate = DateTime.Now;
        repo.Add(file);
    }
}
