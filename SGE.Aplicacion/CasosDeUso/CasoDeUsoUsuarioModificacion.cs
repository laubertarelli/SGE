namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioModificacion(IUsuarioRepositorio repoUser, IServicioHash hashing, UsuarioValidador validador)
{
    public void Ejecutar(Usuario user, string email, string password)
    {
        if (!validador.EsValido(user, out string msg))
        {
            throw new ValidacionException(msg);
        }
        if (!user.Email.Equals(email) && repoUser.GetUsuario(email) is not null)
        {
            throw new UsuarioException("El email ya esta registrado");
        }
        if (!hashing.Validate(password, user.Contraseña))
        {
            throw new UsuarioException("La contraseña es incorrecta");
        }
        user.Email = email;
        repoUser.ModificarUsuario(user);
    }
}
