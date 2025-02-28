using EndpointType.Models;
using Microsoft.AspNetCore.Mvc;

namespace EndpointType.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        [HttpGet("poo/{nome}")]
        public IActionResult GetAnimalSound(string nome)
        {
            Animal cachorro = new Cachorro(nome);
            cachorro.FazerSom();
            return Ok($"{cachorro.Nome} fez um som");
        }

        [HttpGet("tratamento-excecao/{nome}")]
        public IActionResult GetAnimalByName(string nome)
        {
            try
            {
                if (string.IsNullOrEmpty(nome))
                    throw new AnimalNaoEncontradoException("Animal não encontrado.");

                if (nome.ToLower() != "REX")
                    throw new AnimalNaoEncontradoException("O animal com o nome fornecido não foi encontrado.");

                return Ok($"O animal {nome} foi encontrado!");
            }
            catch (AnimalNaoEncontradoException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        //Tratamento de erro
        public class AnimalNaoEncontradoException : Exception
        {
            public AnimalNaoEncontradoException(string mensagem) : base(mensagem) { }
        }

    }
}
