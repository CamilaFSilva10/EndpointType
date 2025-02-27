namespace EndpointType.Models
{
    // Animal.cs
    public abstract class Animal
    {
        public string Nome { get; set; }

        public Animal(string nome)
        {
            Nome = nome;
        }

        public abstract void FazerSom();
    }

    // Cachorro.cs (Herança e Polimorfismo)
    public class Cachorro : Animal
    {
        public Cachorro(string nome) : base(nome) { }

        public override void FazerSom()
        {
            Console.WriteLine($"{Nome} está latindo!");
        }
    }

}
