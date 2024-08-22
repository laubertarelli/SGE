namespace SGE.Application;

public class DeleteUserUseCase(IUserRepository repo)
{
    public void Execute(int id) => repo.Delete(id);
}
