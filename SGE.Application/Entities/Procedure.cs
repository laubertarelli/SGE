namespace SGE.Application;

public class Procedure
{
    public int Id { get; set; }
    public File File { get; set; } = null!;
    public int FileId { get; set; }
    public User? LastEditor { get; set; }
    public int UserId { get; set; }
    public ProcedureLabel Label { get; set; }
    public string Content { get; set; } = "";
    public DateTime CreationDate { get; set; }
    public DateTime EditionDate { get; set; }
}
