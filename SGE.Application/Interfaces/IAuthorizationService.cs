namespace SGE.Application;

public interface IAuthorizationService
{
    public bool IsAllowed(User user, Permission permission);
}
