namespace SGE.Application;

public class UserValidator
{
    public bool IsValid(User user, out string message)
    {
        message = "";
        if (string.IsNullOrWhiteSpace(user.FirstName))
        {
            message = "First name cannot be empty";
        }
        else if (string.IsNullOrWhiteSpace(user.LastName))
        {
            message = "Last name cannot be empty";
        }
        else if (string.IsNullOrWhiteSpace(user.Email))
        {
            message = "Email cannot be empty";
        }
        else if (string.IsNullOrWhiteSpace(user.Password))
        {
            message = "Password cannot be empty";
        }
        else if (user.Password.Length < 8)
        {
            message = "Password must be at least 8 characters long";
        }
        return message == "";
    }

}
