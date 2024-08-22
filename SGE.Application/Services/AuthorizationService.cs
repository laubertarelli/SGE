namespace SGE.Application;

public class AuthorizationService : IAuthorizationService
{
    public bool IsAllowed(User user, Permission permission)
    {
        return user.IsAdmin || user.Permissions.Any(p => p == permission);
    }
}
