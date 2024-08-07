namespace SGE.Aplicacion;

public class CasoDeUsoTramiteModificacion(ITramiteRepositorio repoTram, IServicioAutorizacion auth, TramiteValidador validador, IServicioActualizacionEstado actEstado)
{
    public void Ejecutar(Tramite t, Usuario user)
    {
        if (!auth.PoseeElPermiso(user, Permiso.TramiteModificacion))
        {
            throw new AutorizacionException();
        }
        if (!validador.EsValido(t, out string msg))
        {
            throw new ValidacionException(msg);
        }
        t.IdUser = user.Id;
        t.FechayHoraMod = DateTime.Now;
        repoTram.ModificacionTramite(t);
        actEstado.ActualizarEstado(t.ExpedienteId);
    }
}
