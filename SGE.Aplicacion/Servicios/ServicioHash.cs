using System.Security.Cryptography;
using System.Text;

namespace SGE.Aplicacion;

public class ServicioHash : IServicioHash
{
    public string Encrypt(string password)
    {
        // Compute hash from password
        byte[] hashedBytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));

        // Convert byte array to a string
        StringBuilder builder = new();
        for (int i = 0; i < hashedBytes.Length; i++)
        {
            //converted to its hexadecimal representation using the ToString("x2") 
            builder.Append(hashedBytes[i].ToString("x2"));
        }
        return builder.ToString();
    }

    public bool Validate(string txt, string hash) => Encrypt(txt).Equals(hash) || txt.Equals(hash);
}
