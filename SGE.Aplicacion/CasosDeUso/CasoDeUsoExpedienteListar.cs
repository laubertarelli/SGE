namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteListar(IExpedienteRepositorio repo)
{
    public List<Expediente> Ejecutar(int page) => repo.ListarExpedientes(page);
}
