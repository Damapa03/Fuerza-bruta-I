using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        String contraseniaHashed = GenerarHashSHA256("!!!Daniel");
            
        string[] listaRecortada = new string[40];
        try
        {
            string[] contrasenias = File.ReadAllLines("..\\..\\..\\Password\\2151220-passwords.txt");
            
            Array.Copy(contrasenias, listaRecortada, 40);
            
        }
        catch (IOException e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
        
        fuerzaBruta(contraseniaHashed, listaRecortada);
        
    }
    
    static string GenerarHashSHA256(string texto)
    {
        // Crear el objeto SHA256
        using (SHA256 sha256 = SHA256.Create())
        {
            // Convertir el texto a bytes
            byte[] bytesTexto = Encoding.UTF8.GetBytes(texto);

            // Calcular el hash
            byte[] hashBytes = sha256.ComputeHash(bytesTexto);

            // Convertir los bytes del hash a una representación hexadecimal
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                sb.Append(b.ToString("x2")); // Formato hexadecimal (dos dígitos)
            }

            return sb.ToString();
        }
    }

    static void fuerzaBruta(String contraseniaHashed, string[] listaRecortada)
    {
        Boolean flag = false;
        
        foreach (var password in listaRecortada)
        {
            Console.WriteLine(password);
            if (contraseniaHashed == GenerarHashSHA256(password))
            {
                flag = true;
            }
        }

        if (flag)
        {
            Console.WriteLine("Fuerza bruta con exito");
        }
    }
}