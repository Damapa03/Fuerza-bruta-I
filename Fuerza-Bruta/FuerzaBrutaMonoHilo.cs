namespace Fuerza_Bruta;

public class FuerzaBrutaMonoHilo
{
    public void fuerzaBrutaMonoHilo(String contraseniaHashed, string[] listaRecortada)
    {
        HashGenerator hashGenerator = new HashGenerator();
        Boolean flag = false;
        
        foreach (var password in listaRecortada)
        {
            Console.WriteLine(password);
            if (contraseniaHashed == hashGenerator.GenerarHashSHA256(password))
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