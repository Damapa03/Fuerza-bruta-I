using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Fuerza_Bruta;

class FuerzaBrutaMultiHilo
{
    public void fuerzaBrutaMultiHilo(String contraseniaHashed, string[] lista)
    {
        HashGenerator hashGenerator = new HashGenerator();
        string? resultado = null;
        object lockObj = new object();
        double? ms = null;
        
        Parallel.ForEach(lista, (contrasenia, estado) =>
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            string contraseniaComprobacion = hashGenerator.GenerarHashSHA256(contrasenia);
            if (contraseniaComprobacion == contraseniaHashed)
            {
                stopwatch.Stop();
                ms = stopwatch.Elapsed.TotalMilliseconds;
                lock (lockObj)
                {
                    resultado = contrasenia;
                    estado.Stop(); 
                }
            }
        });
        
        Console.WriteLine(resultado != null ? $"Contraseña encontrada: {resultado}, tiempo: {ms}" : "Contraseña no encontrada.");
    }
}