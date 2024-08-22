namespace SGE.Application;

public class SignupUserUseCase(IUserRepository repo, IHashService hashService, UserValidator validator)
{
    public void Execute(User user)
    {
        if (!validator.IsValid(user, out string message))
        {
            throw new ValidationException(message);
        }
        if (repo.GetByEmail(user.Email) is not null)
        {
            throw new UserException("Email already registered");
        }
        user.Password = hashService.Encrypt(user.Password);
        user.CreationDate = DateTime.Now;
        repo.Signup(user);
    }
}
