namespace SGE.Aplicacion;
public class CasoDeUsoUsuarioModContraseña(IUsuarioRepositorio repo, IServicioHash hashing)
{
	public void Ejecutar(Usuario user, string currentPassword, string newPassword)
	{
		if (string.IsNullOrEmpty(newPassword))
		{
			throw new UsuarioException("La contraseña no puede estar vacia");
		}
		if (!hashing.Validate(currentPassword, user.Contraseña))
		{
			throw new UsuarioException("La contraseña actual es incorrecta");
		}
		repo.ModificarContraseña(user.Id, hashing.Encrypt(newPassword));
	}
}
