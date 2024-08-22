namespace SGE.Application;

public class LoginUserUseCase(IUserRepository repo, IHashService hashService)
{
    public User Execute(string email, string password)
    {
        User? user = repo.GetByEmail(email);
        if (user is null)
        {
            throw new UserException("Invalid email");
        }
        if (!hashService.Validate(password, user.Password))
        {
            throw new UserException("Invalid password");
        }
        return user;
    }
}
