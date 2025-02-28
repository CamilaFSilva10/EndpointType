namespace EndpointType.Models.Exemplo_Herança_e_Polimorfismo
{
    public class Bicicleta : Veiculo
    {
        //(Herança e Polimorfismo)
        public Bicicleta(string tipo) : base(tipo) { }

        public override void Mover()
        {
            Console.WriteLine($"A Bicicleta está se movendo!");
        }
    }
}