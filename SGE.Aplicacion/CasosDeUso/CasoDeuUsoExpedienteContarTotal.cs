namespace SGE.Aplicacion;
public class CasoDeuUsoExpedienteContarTotal(IExpedienteRepositorio repo)
{
    public int Ejecutar() => repo.ContarTotal();
}
