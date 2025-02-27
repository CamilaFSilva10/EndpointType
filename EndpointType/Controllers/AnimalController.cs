using EndpointType.Models;
using Microsoft.AspNetCore.Mvc;

namespace EndpointType.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        [HttpGet("poo")]
        public IActionResult GetAnimalSound()
        {
            Animal cachorro = new Cachorro("Rex");
            cachorro.FazerSom();
            return Ok($"{cachorro.Nome} fez um som");
        }
        public class AnimalNaoEncontradoException : Exception
        {
            public AnimalNaoEncontradoException(string mensagem) : base(mensagem) { }
        }

        [HttpGet("tratamento-excecao/{nome}")]
        public IActionResult GetAnimalByName(string nome)
        {
            try
            {
                if (string.IsNullOrEmpty(nome))
                    throw new AnimalNaoEncontradoException("Animal não encontrado.");

                // Simulando a busca do animal
                if (nome.ToLower() != "Rex")
                    throw new AnimalNaoEncontradoException("O animal com o nome fornecido não foi encontrado.");

                return Ok($"O animal {nome} foi encontrado!");
            }
            catch (AnimalNaoEncontradoException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}
