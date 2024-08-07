namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio repo, IServicioAutorizacion auth)
{
    public void Ejecutar(int id, Usuario user)
    {
        if (!auth.PoseeElPermiso(user, Permiso.ExpedienteBaja))
        {
            throw new AutorizacionException();
        }
        repo.BajaExpediente(id);
    }
}
