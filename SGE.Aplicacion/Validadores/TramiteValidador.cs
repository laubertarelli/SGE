namespace SGE.Aplicacion;

public class TramiteValidador
{
    public bool EsValido(Tramite t, out string msg)
    {
        msg = "";
        if (string.IsNullOrWhiteSpace(t.Contenido))
        {
            msg += "El contenido no puede ser vacio \n";
        }
        return msg == "";
    }
}
