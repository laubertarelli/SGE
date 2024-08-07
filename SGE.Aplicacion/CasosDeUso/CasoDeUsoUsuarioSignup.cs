namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioSignup(IUsuarioRepositorio repoUser, IServicioHash hashing, UsuarioValidador validador)
{
    public void Ejecutar(Usuario user)
    {
        if (!validador.EsValido(user, out string msg))
        {
            throw new ValidacionException(msg);
        }
        if (repoUser.GetUsuario(user.Email) is not null)
        {
            throw new UsuarioException("El email ya esta registrado");
        }
        user.Contraseña = hashing.Encrypt(user.Contraseña);
        user.FechayHoraMod = DateTime.Now;
        user.FechayHoraCr = DateTime.Now;
        repoUser.Signup(user);
    }
}
