using SGE.Aplicacion;
namespace SGE.Repositorios;

public class RepositorioExpediente : IExpedienteRepositorio
{
    public void AltaExpediente(Expediente e)
    {
        using var context = new BaseContext();
        context.Expedientes.Add(e);
        context.SaveChanges();
    }

    public void BajaExpediente(int id)
    {
        using var context = new BaseContext();
        var e = context.Expedientes.Where(t => t.Id == id).SingleOrDefault();
        if (e != null)
        {
            context.Expedientes.Remove(e);
        }
        context.SaveChanges();
    }

    public void ModificarExpediente(Expediente nuevoE)
    {
        using var context = new BaseContext();
        var e = context.Expedientes.Where(e => e.Id == nuevoE.Id).SingleOrDefault();
        if (e != null)
        {
            e.Caratula = nuevoE.Caratula;
            e.Estado = nuevoE.Estado;
        }
        context.SaveChanges();
    }

    public Expediente? ConsultaPorId(int id)
    {
        using var context = new BaseContext();
        return context.Expedientes.Where(e => e.Id == id).SingleOrDefault();
    }

    public List<object> ConsultaTodos(int id)
    {
        using var context = new BaseContext();
        List<object> lista = [];
        var exp = context.Expedientes.Where(e => e.Id == id).SingleOrDefault();
        if (exp != null)
        {
            lista.Add(exp);
            var tramites = context.Tramites.Where(t => t.ExpedienteId == id).ToList();
            lista.AddRange(tramites);
        }
        return lista;
    }

    public int ContarTotal()
    {
        using var context = new BaseContext();
        return context.Expedientes.Count();
    }

    public List<Expediente> ListarExpedientes(int page)
    {
        using var context = new BaseContext();
        return context.Expedientes.Skip((page - 1) * 5).Take(5).ToList();
    }
}
