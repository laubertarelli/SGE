namespace SGE.Application;

public class GrantUserPermissionUseCase(IUserRepository repo)
{
    public void Execute(int id, Permission permission) => repo.GrantPermission(id, permission);
}
