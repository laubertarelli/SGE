namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioListar(IUsuarioRepositorio repoUser)
{
    public List<Usuario> Ejecutar(int page) => repoUser.ListarUsuarios(page);
}
