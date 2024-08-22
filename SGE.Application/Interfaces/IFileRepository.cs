namespace SGE.Application;
public interface IFileRepository
{
    public void Add(File file);
    public void Delete(int id);
    public void Update(File file);
    public File? GetById(int id);
    public List<File> GetAll(int page);
    public int CountAll();
}
