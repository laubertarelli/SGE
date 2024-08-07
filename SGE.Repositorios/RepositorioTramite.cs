using SGE.Aplicacion;
namespace SGE.Repositorios;

public class RepositorioTramite(BaseContext context) : ITramiteRepositorio
{
    public void AltaTramite(Tramite t)
    {
        context.Tramites.Add(t);
        context.SaveChanges();
    }

    public void BajaTramite(int id)
    {
        Tramite t = context.Tramites.Where(t => t.Id == id).Single();
        context.Tramites.Remove(t);
        context.SaveChanges();
    }

    public void ModificacionTramite(Tramite t)
    {
        context.Tramites.Update(t);
        context.SaveChanges();
    }

    public List<Tramite> ListarTramites(int page) => context.Tramites.Skip((page - 1) * 5).Take(5).ToList();
    public int ContarTotal() => context.Tramites.Count();
    public int ContarPorEtiqueta(EtiquetaTramite e) => context.Tramites.Where(t => t.Etiqueta == e).Count();
    public List<Tramite> ConsultaPorEtiqueta(EtiquetaTramite e, int page) => context.Tramites.Where(t => t.Etiqueta == e).Skip((page - 1) * 5).Take(5).ToList();
    public Tramite? ConsultaPorId(int id) => context.Tramites.Where(t => t.Id == id).SingleOrDefault();
    public List<Tramite> ConsultaPorExpedienteId(int expId) => context.Tramites.Where(t => t.ExpedienteId == expId).ToList();

}
