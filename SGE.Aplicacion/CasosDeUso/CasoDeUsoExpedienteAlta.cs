namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteAlta(IExpedienteRepositorio repo, IServicioAutorizacion auth, ExpedienteValidador validador)
{
    public void Ejecutar(Expediente e, Usuario user)
    {
        if (!auth.PoseeElPermiso(user, Permiso.ExpedienteAlta))
        {
            throw new AutorizacionException();
        }
        if (!validador.EsValido(e, out string msg))
        {
            throw new ValidacionException(msg);
        }
        e.IdUser = user.Id;
        e.FechayHoraCr = DateTime.Now;
        e.FechayHoraMod = DateTime.Now;
        repo.AltaExpediente(e);
    }
}
