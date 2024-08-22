namespace SGE.Application;
public class CountAllUsersUseCase(IUserRepository repo)
{
    public int Execute() => repo.CountAll();
}
