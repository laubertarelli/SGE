using SGE.Aplicacion;

namespace SGE.Repositorios;

public class RepositorioUsuarios(BaseContext context) : IUsuarioRepositorio
{
    public void Signup(Usuario user)
    {
        context.Usuarios.Add(user);
        context.SaveChanges();
    }

    public void EliminarUsuario(int id)
    {
        Usuario? user = context.Usuarios.Where(x => x.Id == id).SingleOrDefault();
        if (user != null)
            context.Usuarios.Remove(user);
        context.SaveChanges();
    }

    public Usuario? GetUsuario(string email) => context.Usuarios.Where(u => u.Email == email).SingleOrDefault();

    public void ModificarUsuario(Usuario u)
    {
        context.Usuarios.Update(u);
        context.SaveChanges();
    }

    public Usuario? ConsultaPorId(int id) => context.Usuarios.Where(u => u.Id == id).SingleOrDefault();
    public int ContarTotal() => context.Usuarios.Count();
    public List<Usuario> ListarUsuarios(int page) => context.Usuarios.Skip((page - 1) * 5).Take(5).ToList();

    public void OtorgarPermiso(int id, Permiso p)
    {
        Usuario? user = context.Usuarios.Where(u => u.Id == id).SingleOrDefault();
        if (user != null)
        {
            user.Permisos.Add(p);
        }
        context.SaveChanges();
    }
    public void QuitarPermiso(int id, Permiso p)
    {
        Usuario? user = context.Usuarios.Where(u => u.Id == id).SingleOrDefault();
        if (user != null)
        {
            user.Permisos.Remove(p);
        }
        context.SaveChanges();
    }
}
