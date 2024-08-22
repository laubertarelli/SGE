namespace SGE.Application;

public interface IHashService
{
    public string Encrypt(string password);
    public bool Validate(string txt, string hash);
}
