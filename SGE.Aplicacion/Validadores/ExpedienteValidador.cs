namespace SGE.Aplicacion;

public class ExpedienteValidador
{
    public bool EsValido(Expediente e, out string msg)
    {
        msg = "";
        if (string.IsNullOrWhiteSpace(e.Caratula))
        {
            msg += "La caratula no puede estar vacia \n";
        }
        return msg == "";
    }
}
