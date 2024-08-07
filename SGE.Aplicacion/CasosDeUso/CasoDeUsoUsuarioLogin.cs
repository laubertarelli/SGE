namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioLogin(IUsuarioRepositorio repoUser, IServicioHash hashing)
{
    public Usuario Ejecutar(string email, string pass)
    {
        Usuario? user = repoUser.GetUsuario(email);
        if (user is null)
        {
            throw new UsuarioException("Email incorrecto");
        }
        if (!hashing.Validate(pass, user.Contraseña))
        {
            throw new UsuarioException("Contraseña incorrecta");
        }
        return user;
    }
}
