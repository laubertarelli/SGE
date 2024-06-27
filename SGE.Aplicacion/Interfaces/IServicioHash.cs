namespace SGE.Aplicacion;

public interface IServicioHash
{
    public string Encrypt(string password);
    public bool Validate(string txt, string hash);
}
