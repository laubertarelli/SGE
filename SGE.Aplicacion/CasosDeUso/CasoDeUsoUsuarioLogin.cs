namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioLogin(IUsuarioRepositorio repoUser, IServicioHash hashing)
{
    public Usuario Ejecutar(string email, string pass)
    {
        Usuario? user = repoUser.GetUsuario(email);
        if (user is null)
        {
            throw new UsuarioException("El email ingresado no existe");
        }
        if (!hashing.Validate(pass, user.Contraseña))
        {
            throw new UsuarioException("La contraseña ingresada es incorrecta");
        }
        return user;
    }
}
