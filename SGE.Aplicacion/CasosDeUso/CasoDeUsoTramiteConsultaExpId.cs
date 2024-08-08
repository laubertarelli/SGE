namespace SGE.Aplicacion;

public class CasoDeUsoTramiteConsultaExpId(ITramiteRepositorio repo)
{
    public List<Tramite> Ejecutar(int expId, int page) => repo.ConsultaPorExpId(expId, page);
}
