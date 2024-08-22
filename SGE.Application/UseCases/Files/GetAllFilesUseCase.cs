namespace SGE.Application;

public class GetAllFilesUseCase(IFileRepository repo)
{
    public List<File> Execute(int page) => repo.GetAll(page);
}
