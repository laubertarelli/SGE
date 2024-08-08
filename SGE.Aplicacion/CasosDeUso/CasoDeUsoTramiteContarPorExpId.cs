namespace SGE.Aplicacion
{
    public class CasoDeUsoTramiteContarPorExpId(ITramiteRepositorio repo)
    {
        public int Ejecutar(int expId) => repo.ContarPorExpId(expId);
    }
}
