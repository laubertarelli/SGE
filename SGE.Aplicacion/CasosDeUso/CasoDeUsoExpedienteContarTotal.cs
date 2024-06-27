namespace SGE.Aplicacion;
public class CasoDeUsoExpedienteContarTotal(IExpedienteRepositorio repo)
{
    public int Ejecutar() => repo.ContarTotal();
}
