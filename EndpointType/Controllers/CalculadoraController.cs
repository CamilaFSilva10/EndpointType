using EndpointType.Models;
using Microsoft.AspNetCore.Mvc;

namespace EndpointType.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculadoraController : ControllerBase
    {
        [HttpGet("somar-estatico/{a}/{b}")]
        public IActionResult SomarEstatico(int a, int b)
        {
            int resultado = Calculadora.Somar(a, b); // Método estático
            return Ok($"Resultado da soma estática: {resultado}");
        }

        [HttpGet("somar-sobrecarga/{a}/{b}/{c}")]
        public IActionResult SomarSobrecarga(int a, int b, int c)
        {
            Calculadora calculadora = new Calculadora();
            int resultado = calculadora.Somar(a, b, c); // Sobrecarga de método
            return Ok($"Resultado da soma com sobrecarga: {resultado}");
        }
    }
}
