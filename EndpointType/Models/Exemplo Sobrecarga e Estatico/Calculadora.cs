namespace EndpointType.Models
{
    public class Calculadora
    {
        // Método estático
        public static int Somar(int a, int b)
        {
            return a + b;
        }

        // Sobrecarga de método: definir métodos com o mesmo nome, mas com diferentes parâmetros.
        public int Somar(int a, int b, int c)
        {
            return a + b + c;
        }

    }
}
