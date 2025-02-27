namespace EndpointType.Models
{
    public class Calculadora
    {
        // Método estático
        public static int Somar(int a, int b)
        {
            return a + b;
        }

        // Sobrecarga de método
        public int Somar(int a, int b, int c)
        {
            return a + b + c;
        }

    }
}
