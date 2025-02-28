namespace EndpointType.Models
{
    public class Cachorro : Animal
    {
        // Cachorro.cs (Herança e Polimorfismo)
        public Cachorro(string nome) : base(nome) { }

        public override void FazerSom()
        {
            Console.WriteLine($"{Nome} está latindo!");
        }
    }
}