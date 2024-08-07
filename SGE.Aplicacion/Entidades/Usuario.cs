namespace SGE.Aplicacion;

public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public string Apellido { get; set; } = "";
    public string Email { get; set; } = "";
    public string Contraseña { get; set; } = "";
    public DateTime FechayHoraMod { get; set; }
    public DateTime FechayHoraCr { get; set; }
    public List<Permiso> Permisos { get; set; } = [];
    public bool IsAdmin => Id == 1;
    public string NombreCompleto => $"{Nombre} {Apellido}";

    public string GetPermisoParsed(Permiso p)
    {
        return p switch
        {
            Permiso.ExpedienteAlta => "Alta de Expediente",
            Permiso.ExpedienteBaja => "Baja de Expediente",
            Permiso.ExpedienteModificacion => "Modificacion de Expediente",
            Permiso.TramiteAlta => "Alta de Tramite",
            Permiso.TramiteBaja => "Baja de Tramite",
            Permiso.TramiteModificacion => "Modificacion de Tramite",
            _ => "Error",
        };
    }
}
