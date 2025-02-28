namespace EndpointType.Models
{
    public class Carro : Veiculo
    {
        //(Herança e Polimorfismo)
        public Carro(string tipo) : base(tipo) { }

        public override void Mover()
        {
            Console.WriteLine($"O carro está se movendo!");
        }
    }
}