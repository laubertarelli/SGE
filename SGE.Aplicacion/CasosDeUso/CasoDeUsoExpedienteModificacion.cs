namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteModificacion(IExpedienteRepositorio repo, IServicioAutorizacion auth, ExpedienteValidador validador)
{
    public void Ejecutar(Expediente e, Usuario user)
    {
        if (!auth.PoseeElPermiso(user, Permiso.ExpedienteModificacion))
        {
            throw new AutorizacionException();
        }
        if (!validador.EsValido(e, out string msg))
        {
            throw new ValidacionException(msg);
        }
        e.IdUser = user.Id;
        e.FechayHoraMod = DateTime.Now;
        repo.ModificarExpediente(e);
    }
}
