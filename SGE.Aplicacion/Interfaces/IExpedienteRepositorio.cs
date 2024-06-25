namespace SGE.Aplicacion;
public interface IExpedienteRepositorio
{
    public void AltaExpediente(Expediente e);
    public void BajaExpediente(int id);
    public void ModificarExpediente(Expediente e);
    public Expediente? ConsultaPorId(int id);
    public List<object> ConsultaTodos(int id);
    public List<Expediente> ListarExpedientes(int page);
    public int ContarTotal();
}
