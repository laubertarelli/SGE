namespace SGE.Application;
public class UpdateUserPasswordUseCase(IUserRepository repo, IHashService hashService)
{
    public void Execute(User user, string currentPassword, string newPassword)
    {
        if (newPassword.Length < 8)
        {
            throw new UserException("Password must be at least 8 characters long");
        }
        if (!hashService.Validate(currentPassword, user.Password))
        {
            throw new UserException("Invalid password");
        }
        user.Password = hashService.Encrypt(newPassword);
        repo.Update(user);
    }
}
