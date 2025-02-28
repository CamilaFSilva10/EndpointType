namespace EndpointType.Models
{
    public abstract class Veiculo
    {
        public string Tipo { get; set; }

        public Veiculo(string tipo)
        {
            Tipo = tipo;
        }

        public abstract void Mover();
    }
}
