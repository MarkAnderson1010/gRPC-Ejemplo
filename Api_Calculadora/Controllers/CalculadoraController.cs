using Grpc.Net.Client;
using Grpc_miPrueba;
using Microsoft.AspNetCore.Mvc;

namespace Api_Calculadora.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculadoraController : ControllerBase
    {
        private GrpcChannel _channel = GrpcChannel.ForAddress("https://localhost:7171");
        private Calculador.CalculadorClient _calculador;
        
        #region POST
        [HttpPost]
        public async Task<IActionResult> PostSumar(int numero1,int numero2)
        {
            _calculador     = new Calculador.CalculadorClient(_channel);
            var sumaRequest = new SumaRequest { Numero1 = numero1, Numero2 = numero2 };   
            
            var sumaRequestResultado = await _calculador.SumarAsync(sumaRequest);
            
            return Ok(sumaRequestResultado.Resultado);
        }
        #endregion
    }
}
