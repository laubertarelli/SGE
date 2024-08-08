namespace SGE.Aplicacion;

public class UsuarioValidador
{
    public bool EsValido(Usuario user, out string msg)
    {
        msg = "";
        if (user.Nombre == "")
        {
            msg += "El nombre no puede estar vacio ||\n";
        }
        if (user.Apellido == "")
        {
            msg += "El apellido no puede estar vacio ||\n";
        }
        if (user.Email == "")
        {
            msg += "El email no puede estar vacio ||\n";
        }
        if (user.Contraseña.Length < 8)
        {
            msg += "La contraseña no puede tener menos de 8 carácteres";
        }
        return msg == "";
    }

}
