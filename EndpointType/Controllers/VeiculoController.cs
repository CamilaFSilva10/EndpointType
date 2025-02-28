using EndpointType.Models;
using EndpointType.Models.Exemplo_Herança_e_Polimorfismo;
using Microsoft.AspNetCore.Mvc;

namespace EndpointType.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        [HttpGet("listar")]
        public IActionResult GetAllVeiculos()
        {
            return Ok($"Veículos cadastrados no sistema: Carro, Moto, Bicicleta");
        }

        [HttpGet("poo/{tipo}")]
        public IActionResult GetVeiculo(string tipo)
        {
            if (tipo.Equals("CARRO", StringComparison.CurrentCultureIgnoreCase))
            {
                Veiculo veiculo = new Carro(tipo);
                veiculo.Mover();
                return Ok($"{veiculo.Tipo} se moveu");
            }
            if (tipo.Equals("MOTO", StringComparison.CurrentCultureIgnoreCase))
            {
                Veiculo veiculo = new Moto(tipo);
                veiculo.Mover();
                return Ok($"{veiculo.Tipo} se moveu");
            }
            if (tipo.Equals("BICICLETA", StringComparison.CurrentCultureIgnoreCase))
            {
                Veiculo veiculo = new Bicicleta(tipo);
                veiculo.Mover();
                return Ok($"{veiculo.Tipo} se moveu");
            }
            else
            {
                return BadRequest("Veículo não encontrado.");
            }
        }

        [HttpGet("tratamento-excecao/{tipo}")]
        public IActionResult GetVeiculoByName(string tipo)
        {
            try
            {
                if (string.IsNullOrEmpty(tipo))
                    throw new VeiculoNaoEncontradoException("Veículo não encontrado.");

                if (!tipo.Equals("CARRO", StringComparison.CurrentCultureIgnoreCase) &&
                    !tipo.Equals("MOTO", StringComparison.CurrentCultureIgnoreCase) &&
                    !tipo.Equals("BICICLETA", StringComparison.CurrentCultureIgnoreCase))
                    throw new VeiculoNaoEncontradoException("O veículo do tipo fornecido não foi encontrado.");

                return Ok($"O veículo do tipo {tipo} foi encontrado!");
            }
            catch (VeiculoNaoEncontradoException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        //Tratamento de erro
        public class VeiculoNaoEncontradoException : Exception
        {
            public VeiculoNaoEncontradoException(string mensagem) : base(mensagem) { }
        }

    }
}
