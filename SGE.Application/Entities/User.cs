namespace SGE.Application;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
    public DateTime CreationDate { get; set; }
    public DateTime EditionDate { get; set; }
    public List<File> Files { get; set; } = [];
    public List<Procedure> Procedures { get; set; } = [];
    public List<Permission> Permissions { get; set; } = [];

    public bool IsAdmin => Id == 1;
    public string FullName => $"{FirstName} {LastName}";

    public string GetPermissionParsed(Permission permission)
    {
        return permission switch
        {
            Permission.AddFile => "Add file",
            Permission.DeleteFile => "Delete file",
            Permission.UpdateFile => "Update file",
            Permission.AddProcedure => "Add procedure",
            Permission.DeleteProcedure => "Delete procedure",
            Permission.UpdateProcedure => "Update procedure",
            _ => "Error",
        };
    }
}
