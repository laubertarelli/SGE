namespace SGE.Application;

public class GetAllUsersUseCase(IUserRepository repo)
{
    public List<User> Execute(int page) => repo.GetAll(page);
}
