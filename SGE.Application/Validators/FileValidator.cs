namespace SGE.Application;

public class FileValidator
{
    public bool IsValid(File file, out string message)
    {
        message = "";
        if (string.IsNullOrWhiteSpace(file.Cover))
        {
            message = "Cover cannot be empty";
        }
        return message == "";
    }
}
