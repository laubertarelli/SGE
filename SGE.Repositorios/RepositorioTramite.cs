using SGE.Aplicacion;
namespace SGE.Repositorios;

public class RepositorioTramite : ITramiteRepositorio
{
    public void AltaTramite(Tramite t)
    {
        using var context = new BaseContext();
        context.Tramites.Add(t);
        context.SaveChanges();
    }

    public void BajaTramite(int id)
    {
        using var context = new BaseContext();
        Tramite? t = context.Tramites.Where(t => t.Id == id).SingleOrDefault();
        if (t != null)
        {
            context.Tramites.Remove(t);
        }
        context.SaveChanges();
    }

    public void ModificacionTramite(Tramite nuevoT)
    {
        using var context = new BaseContext();
        Tramite? t = context.Tramites.Where(t => t.Id == nuevoT.Id).SingleOrDefault();
        if (t != null)
        {
            t.Contenido = nuevoT.Contenido;
            t.Etiqueta = nuevoT.Etiqueta;
        }
        context.SaveChanges();
    }

    public List<Tramite> ListarTramites(int page)
    {
        using var context = new BaseContext();
        return context.Tramites.Skip((page - 1) * 5).Take(5).ToList();
    }

    public int ContarTotal()
    {
        using var context = new BaseContext();
        return context.Tramites.Count();
    }

    public List<Tramite> ConsultaPorEtiqueta(EtiquetaTramite e)
    {
        using var context = new BaseContext();
        return context.Tramites.Where(t => t.Etiqueta == e).ToList();
    }

    public Tramite? ConsultaPorId(int id)
    {
        using var context = new BaseContext();
        return context.Tramites.Where(t => t.Id == id).SingleOrDefault();
    }

    public List<Tramite> ConsultaPorExpedienteId(int expId)
    {
        using var context = new BaseContext();
        return context.Tramites.Where(t => t.ExpedienteId == expId).ToList();
    }

}
