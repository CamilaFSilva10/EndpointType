namespace EndpointType.Models.Exemplo_Herança_e_Polimorfismo
{
    public class Moto : Veiculo
    {
        //(Herança e Polimorfismo)
        public Moto(string tipo) : base(tipo) { }

        public override void Mover()
        {
            Console.WriteLine($"A moto está se movendo!");
        }
    }
}