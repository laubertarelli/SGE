namespace SGE.Application;

public class AuthorizationException(string message = "No tiene los permisos necesarios") : Exception(message) { }
