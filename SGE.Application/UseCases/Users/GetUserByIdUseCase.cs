namespace SGE.Application;

public class GetUserByIdUseCase(IUserRepository repo)
{
    public User Execute(int id)
    {
        User? user = repo.GetById(id);
        if (user is null)
        {
            throw new UserException("User not found");
        }
        return user;
    }
}
