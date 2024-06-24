namespace SGE.Aplicacion;

public class ServicioActualizacionEstado(IExpedienteRepositorio repo, IEspecificacionCambioEstado espec) : IServicioActualizacionEstado
{
  public void ActualizarEstado(int id)
  {
    List<object> lista = repo.ConsultaTodos(id);
    if (lista[^1] is Tramite t) // LAST INDEX
    {
      Expediente e = (Expediente)lista[0];
      EstadoExpediente? nuevoEstado = espec.GetEstado(t.Etiqueta);
      if (e != null && nuevoEstado != null)
      {
        e.Estado = nuevoEstado;
        repo.ModificarExpediente(e);
      }
    }
  }
}
