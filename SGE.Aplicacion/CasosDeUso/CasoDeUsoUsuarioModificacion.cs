namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioModificacion(IUsuarioRepositorio repoUser, IServicioHash hashing, UsuarioValidador validador)
{
    public void Ejecutar(Usuario user, string password)
    {
        if (!validador.EsValido(user, out string msg))
        {
            throw new ValidacionException(msg);
        }
        if (!hashing.Validate(password, user.Contraseña))
        {
            throw new UsuarioException("La contraseña es incorrecta");
        }
        user.FechayHoraMod = DateTime.Now;
        repoUser.ModificarUsuario(user);
    }
}
