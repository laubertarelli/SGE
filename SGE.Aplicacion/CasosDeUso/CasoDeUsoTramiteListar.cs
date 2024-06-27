namespace SGE.Aplicacion;

public class CasoDeUsoTramiteListar(ITramiteRepositorio repo)
{
    public List<Tramite> Ejecutar(int page) => repo.ListarTramites(page);
}
