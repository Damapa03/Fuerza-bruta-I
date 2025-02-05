using System.Security.Cryptography;
using System.Text;
using Fuerza_Bruta;

class Program
{
    static void Main(string[] args)
    {
        HashGenerator hashGenerator = new HashGenerator();
        FuerzaBrutaMonoHilo monoHilo = new FuerzaBrutaMonoHilo();
        FuerzaBrutaMultiHilo multiHilo = new FuerzaBrutaMultiHilo();
        
        String contraseniaHashed = hashGenerator.GenerarHashSHA256("!!!Daniel");

        string[] contrasenias = File.ReadAllLines("..\\..\\..\\Password\\2151220-passwords.txt");
        string[] listaRecortada = new string[40];
        
        Console.WriteLine("Elija el metodo de busqueda:\n1. Mono Hilo\n2. Multi Hilo");
        String opcion = Console.ReadLine();
        if (opcion == "1")
        {
            Array.Copy(contrasenias, listaRecortada, 40);
            monoHilo.fuerzaBrutaMonoHilo(contraseniaHashed, listaRecortada);
        }

        if (opcion == "2")
        {
            multiHilo.fuerzaBrutaMultiHilo(contraseniaHashed, contrasenias);
        }
        
    }

    
}