namespace SGE.Aplicacion;

public class CasoDeUsoTramiteBaja(ITramiteRepositorio repo, IServicioAutorizacion auth, IServicioActualizacionEstado actEstado, CasoDeUsoTramiteConsultaId consulta)
{
    public void Ejecutar(int id, Usuario user)
    {
        if (!auth.PoseeElPermiso(user, Permiso.TramiteBaja))
        {
            throw new AutorizacionException();
        }
        Tramite t = consulta.Ejecutar(id);
        repo.BajaTramite(id);
        actEstado.ActualizarEstado(t.ExpedienteId);
    }
}
