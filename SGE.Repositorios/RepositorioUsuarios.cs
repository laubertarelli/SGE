using SGE.Aplicacion;

namespace SGE.Repositorios;

public class RepositorioUsuarios : IUsuarioRepositorio
{
	public void Signup(Usuario user)
	{
		using var context = new BaseContext();
		context.Usuarios.Add(user);
		context.SaveChanges();
	}

	public void EliminarUsuario(int id)
	{
		using var context = new BaseContext();
		Usuario? user = context.Usuarios.Where(x => x.Id == id).SingleOrDefault();
		if (user != null)
			context.Usuarios.Remove(user);
		context.SaveChanges();
	}

	public Usuario? GetUsuario(string email)
	{
		using var context = new BaseContext();
		return context.Usuarios.Where(u => u.Email == email).SingleOrDefault();
	}

	public void ModificarUsuario(Usuario nuevoU)
	{
		using var context = new BaseContext();
		Usuario user = context.Usuarios.Where(u => u.Id == nuevoU.Id).Single();
		if (user != null)
		{
			user.Apellido = nuevoU.Apellido;
			user.Nombre = nuevoU.Nombre;
			user.Email = nuevoU.Email;
		}
		context.SaveChanges();
	}

	public void ModificarContraseña(int id, string password)
	{
		using var context = new BaseContext();
		Usuario user = context.Usuarios.Where(u => u.Id == id).Single();
		user.Contraseña = password;
		context.SaveChanges();
	}

	public Usuario? ConsultaPorId(int id)
	{
		using var context = new BaseContext();
		return context.Usuarios.Where(u => u.Id == id).SingleOrDefault();
	}

	public List<Usuario> ListarUsuarios()
	{
		using var context = new BaseContext();
		return context.Usuarios.ToList();
	}

	public void OtorgarPermiso(int id, Permiso p)
	{
		using var context = new BaseContext();
		Usuario? user = context.Usuarios.Where(u => u.Id == id).SingleOrDefault();
		if (user != null)
		{
			user.Permisos.Add(p);
		}
		context.SaveChanges();
	}

	public void QuitarPermiso(int id, Permiso p)
	{
		using var context = new BaseContext();
		Usuario? user = context.Usuarios.Where(u => u.Id == id).SingleOrDefault();
		if (user != null)
		{
			user.Permisos.Remove(p);
		}
		context.SaveChanges();
	}
}
