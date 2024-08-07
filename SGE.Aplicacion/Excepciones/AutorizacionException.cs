namespace SGE.Aplicacion;

public class AutorizacionException(string msg = "No tiene los permisos necesarios") : Exception(msg) { }
