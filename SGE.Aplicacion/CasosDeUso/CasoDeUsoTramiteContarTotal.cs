namespace SGE.Aplicacion;
public class CasoDeUsoTramiteContarTotal(ITramiteRepositorio repo)
{
    public int Ejecutar() => repo.ContarTotal();
}
