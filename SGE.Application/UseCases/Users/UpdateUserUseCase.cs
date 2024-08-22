namespace SGE.Application;

public class UpdateUserUseCase(IUserRepository repo, IHashService hashService, UserValidator validator)
{
    public void Execute(User user, string password)
    {
        if (!validator.IsValid(user, out string message))
        {
            throw new ValidationException(message);
        }
        if (!hashService.Validate(password, user.Password))
        {
            throw new UserException("Invalid password");
        }
        repo.Update(user);
    }
}
