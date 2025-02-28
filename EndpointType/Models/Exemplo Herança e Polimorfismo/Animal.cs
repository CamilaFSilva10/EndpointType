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
}
