using Microsoft.EntityFrameworkCore;
using SGE.Application;

namespace SGE.Repositories;

public class UserRepository(FmsContext context) : IUserRepository
{
    public void Signup(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();
    }

    public void Delete(int id)
    {
        User? user = context.Users.Where(u => u.Id == id).SingleOrDefault();
        if (user != null)
            context.Users.Remove(user);
        context.SaveChanges();
    }

    public User? GetByEmail(string email) => context.Users.Include("Files").Include("Procedures").Where(u => u.Email == email).SingleOrDefault();

    public void Update(User u)
    {
        context.Users.Update(u);
        context.SaveChanges();
    }

    public User? GetById(int id) => context.Users.Include("Files").Include("Procedures").Where(u => u.Id == id).SingleOrDefault();
    public int CountAll() => context.Users.Count();
    public List<User> GetAll(int page) => context.Users.Include("Files").Include("Procedures").Skip((page - 1) * 5).Take(5).ToList();

    public void GrantPermission(int id, Permission permission)
    {
        User? user = context.Users.Where(u => u.Id == id).SingleOrDefault();
        if (user is not null)
        {
            user.Permissions.Add(permission);
        }
        context.SaveChanges();
    }
    public void RemovePermission(int id, Permission permission)
    {
        User? user = context.Users.Where(u => u.Id == id).SingleOrDefault();
        if (user is not null)
        {
            user.Permissions.Remove(permission);
        }
        context.SaveChanges();
    }
}
