namespace SGE.Aplicacion;

public class SesionActual
{
    public Usuario? User { get; set; }

    public void CerrarSesion() => User = null;
}
