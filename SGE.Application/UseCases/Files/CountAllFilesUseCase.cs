namespace SGE.Application;
public class CountAllFilesUseCase(IFileRepository repo)
{
    public int Execute() => repo.CountAll();
}
