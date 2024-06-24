namespace SGE.Aplicacion;

public class CasoDeUsoTramiteModificacion(ITramiteRepositorio repoTram, IServicioAutorizacion auth, TramiteValidador validador, IServicioActualizacionEstado actEstado)
{
  public void Ejecutar(Tramite t, Usuario user)
  {
    if (!auth.PoseeElPermiso(user, Permiso.TramiteModificacion))
    {
      throw new AutorizacionException();
    }
    else
    {
      t.IdUser = user.Id;
      if (!validador.EsValido(t, out string msg))
      {
        throw new ValidacionException(msg);
      }
      else
      {
        t.FechayHoraMod = DateTime.Now;
        repoTram.ModificacionTramite(t);
        actEstado.ActualizarEstado(t.ExpedienteId);
      }
      
    }
  }
}
