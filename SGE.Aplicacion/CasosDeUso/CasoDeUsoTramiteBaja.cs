namespace SGE.Aplicacion;

public class CasoDeUsoTramiteBaja(ITramiteRepositorio repoTram, IServicioAutorizacion auth, IServicioActualizacionEstado actEstado)
{
  public void Ejecutar(int id, Usuario user)
  {
    if (!auth.PoseeElPermiso(user, Permiso.TramiteBaja))
    {
      throw new AutorizacionException();
    }
    else
    {
      Tramite? t = repoTram.ConsultaPorId(id);
      repoTram.BajaTramite(id);
      if (t != null)
        actEstado.ActualizarEstado(t.ExpedienteId);
    }
  }
}
