﻿namespace SGE.Aplicacion;

public interface IUsuarioRepositorio
{
    public void Signup(Usuario u);
    public Usuario? GetUsuario(string email);
    public void EliminarUsuario(int id);
    public void ModificarUsuario(Usuario u);
    public Usuario? ConsultaPorId(int id);
    public int ContarTotal();
    public List<Usuario> ListarUsuarios(int page);
    public void OtorgarPermiso(int id, Permiso p);
    public void QuitarPermiso(int id, Permiso p);
}
