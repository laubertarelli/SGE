namespace SGE.Aplicacion;

public class CasoDeUsoTramiteAlta(ITramiteRepositorio repoTram, IServicioAutorizacion auth, TramiteValidador validador, IServicioActualizacionEstado actEstado)
{
    public void Ejecutar(Tramite t, Usuario user)
    {
        if (!auth.PoseeElPermiso(user, Permiso.TramiteAlta))
        {
            throw new AutorizacionException();
        }
        if (!validador.EsValido(t, out string msg))
        {
            throw new ValidacionException(msg);
        }
        t.IdUser = user.Id;
        t.FechayHoraCr = DateTime.Now;
        t.FechayHoraMod = DateTime.Now;
        repoTram.AltaTramite(t);
        actEstado.ActualizarEstado(t.ExpedienteId);
    }
}
