namespace SGE.Aplicacion;

public interface ITramiteRepositorio
{
    public void AltaTramite(Tramite t);
    public void BajaTramite(int id);
    public void ModificacionTramite(Tramite t);
    public List<Tramite> ListarTramites(int page);
    public int ContarTotal();
    public List<Tramite> ConsultaPorEtiqueta(EtiquetaTramite etiqueta);
    public Tramite? ConsultaPorId(int id);
    public List<Tramite> ConsultaPorExpedienteId(int expId);
}
