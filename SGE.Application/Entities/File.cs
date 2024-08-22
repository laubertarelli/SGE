namespace SGE.Application;

public class File
{
    public int Id { get; set; }
    public User? LastEditor { get; set; }
    public int UserId { get; set; }
    public string Cover { get; set; } = "";
    public FileState? State { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime EditionDate { get; set; }
    public List<Procedure> Procedures { get; set; } = [];
}
