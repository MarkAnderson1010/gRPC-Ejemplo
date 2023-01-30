using Grpc.Net.Client;
using Grpc_miPrueba;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClienteWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Greeter.GreeterClient _cliente;
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public string Nombre  { get; set; }
        public string Mensaje { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            var _url   = "https://localhost:7171";
            var _canal = GrpcChannel.ForAddress(_url);
            _cliente   = new Greeter.GreeterClient(_canal);
            
            _logger    = logger;
        }

        public void OnGet()
        {

        }

        public async Task OnPost()
        {
            var helloRequest = new HelloRequest { Name= Nombre };

            var helloRequestResultado =await  _cliente.SayHelloAsync(helloRequest);
            Mensaje = helloRequestResultado.Message;
        }
    }
}