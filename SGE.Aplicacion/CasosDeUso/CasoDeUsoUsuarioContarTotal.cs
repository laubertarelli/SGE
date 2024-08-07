namespace SGE.Aplicacion;
public class CasoDeUsoUsuarioContarTotal(IUsuarioRepositorio repo)
{
    public int Ejecutar() => repo.ContarTotal();
}
