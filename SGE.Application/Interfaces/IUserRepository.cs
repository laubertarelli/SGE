namespace SGE.Application;

public interface IUserRepository
{
    public void Signup(User user);
    public User? GetByEmail(string email);
    public void Delete(int id);
    public void Update(User user);
    public User? GetById(int id);
    public int CountAll();
    public List<User> GetAll(int page);
    public void GrantPermission(int id, Permission permission);
    public void RemovePermission(int id, Permission permission);
}
