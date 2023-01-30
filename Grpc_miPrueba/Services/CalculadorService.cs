using Grpc.Core;

namespace Grpc_miPrueba.Services
{
    public class CalculadorService : Calculador.CalculadorBase
    {
        private readonly ILogger<CalculadorService> _logger;
        public CalculadorService(ILogger<CalculadorService> logger)
        {
            _logger = logger;
        }

        public override Task<SumaReply> Sumar(SumaRequest request, ServerCallContext context)
        {
            return Task.FromResult(new SumaReply
            {
                Resultado = request.Numero1 + request.Numero2
            });
        }
    }
}
