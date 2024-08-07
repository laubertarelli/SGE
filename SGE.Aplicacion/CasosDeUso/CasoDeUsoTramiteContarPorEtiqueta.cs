namespace SGE.Aplicacion
{
    public class CasoDeUsoTramiteContarPorEtiqueta(ITramiteRepositorio repo)
    {
        public int Ejecutar(EtiquetaTramite e) => repo.ContarPorEtiqueta(e);
    }
}
