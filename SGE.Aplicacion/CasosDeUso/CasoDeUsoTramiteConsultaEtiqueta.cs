namespace SGE.Aplicacion;

public class CasoDeUsoTramiteConsultaEtiqueta(ITramiteRepositorio repoTram)
{
    public List<Tramite> Ejecutar(EtiquetaTramite etiqueta, int page)
    {
        return repoTram.ConsultaPorEtiqueta(etiqueta, page);
    }
}
