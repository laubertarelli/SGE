using Microsoft.EntityFrameworkCore;
using SGE.Aplicacion;
namespace SGE.Repositorios;

public class RepositorioExpediente(BaseContext context) : IExpedienteRepositorio
{
    public void AltaExpediente(Expediente e)
    {
        context.Expedientes.Add(e);
        context.SaveChanges();
    }

    public void BajaExpediente(int id)
    {
        Expediente e = context.Expedientes.Where(t => t.Id == id).Single();
        context.Expedientes.Remove(e);
        context.SaveChanges();
    }

    public void ModificarExpediente(Expediente e)
    {
        context.Expedientes.Update(e);
        context.SaveChanges();
    }

    public Expediente? ConsultaPorId(int id) => context.Expedientes.Include("Tramites").Where(e => e.Id == id).SingleOrDefault();
    public int ContarTotal() => context.Expedientes.Count();
    public List<Expediente> ListarExpedientes(int page) => context.Expedientes.Include("Tramites").Skip((page - 1) * 5).Take(5).ToList();
}
