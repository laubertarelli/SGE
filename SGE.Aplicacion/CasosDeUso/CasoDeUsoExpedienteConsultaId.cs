namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaId(IExpedienteRepositorio repo)
{
    public Expediente Ejecutar(int id)
    {
        Expediente? exp = repo.ConsultaPorId(id);
        if (exp is null)
        {
            throw new RepositorioException("El expediente no existe");
        }
        return exp;
    }
}
