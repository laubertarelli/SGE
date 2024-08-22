namespace SGE.Application;

public class RemoveUserPermissionUseCase(IUserRepository repo)
{
    public void Execute(int id, Permission permission) => repo.RemovePermission(id, permission);
}
