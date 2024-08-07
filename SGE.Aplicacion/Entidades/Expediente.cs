namespace SGE.Aplicacion;

public class Expediente
{
    public int Id { get; set; }
    public string Caratula { get; set; } = "";
    public EstadoExpediente? Estado { get; set; }
    public DateTime FechayHoraCr { get; set; }
    public DateTime FechayHoraMod { get; set; }
    public int IdUser { get; set; }
    public List<Tramite> Tramites { get; set; } = [];
}
