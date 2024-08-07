namespace SGE.Aplicacion;

public class ServicioActualizacionEstado(IExpedienteRepositorio repo, IEspecificacionCambioEstado espec, CasoDeUsoExpedienteConsultaId consulta) : IServicioActualizacionEstado
{
    public void ActualizarEstado(int id)
    {
        Expediente e = consulta.Ejecutar(id);
        if (e.Tramites.Count > 0)
        {
            EstadoExpediente? nuevoEstado = espec.GetEstado(e.Tramites[^1].Etiqueta);
            if (nuevoEstado is not null)
            {
                e.Estado = nuevoEstado.Value;
                repo.ModificarExpediente(e);
            }
        }
    }
}
