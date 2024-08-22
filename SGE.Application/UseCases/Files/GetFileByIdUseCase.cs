namespace SGE.Application;

public class GetFileByIdUseCase(IFileRepository repo)
{
    public File Execute(int id)
    {
        File? file = repo.GetById(id);
        if (file is null)
        {
            throw new RepositoryException("File not found");
        }
        return file;
    }
}
