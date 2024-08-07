namespace SGE.Aplicacion;

public interface ITramiteRepositorio
{
    public void AltaTramite(Tramite t);
    public void BajaTramite(int id);
    public void ModificacionTramite(Tramite t);
    public List<Tramite> ListarTramites(int page);
    public int ContarTotal();
    public int ContarPorEtiqueta(EtiquetaTramite etiqueta);
    public List<Tramite> ConsultaPorEtiqueta(EtiquetaTramite etiqueta, int page);
    public Tramite? ConsultaPorId(int id);
    public List<Tramite> ConsultaPorExpedienteId(int expId);
}
