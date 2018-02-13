using Sorte.Configurations;
using Sorte.Domain.ContextMega.Contracts.Services;
using Sorte.DTO.Requests;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Sorte.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api")]
    public class MegaSenaController : ApiController
    {

        private readonly IMegaSenaServico _megaSenaServico;

        public MegaSenaController()
        {
            _megaSenaServico = Fabrica.Obter<IMegaSenaServico>();
        }

        [HttpPost]
        [Route("aposta")]
        public Task<HttpResponseMessage> Criar(CartaoApostaRequest request)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var aposta = _megaSenaServico.CriarCartaoAposta(request.Surpresinha, request.NumerosApostados, request.NomeApostador);
               response = Request.CreateResponse(HttpStatusCode.OK, aposta);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        [HttpGet]
        [Route("aposta")]
        public Task<HttpResponseMessage> Listar()
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var aposta = _megaSenaServico.ListarApostas();
                response = Request.CreateResponse(HttpStatusCode.OK, aposta);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        [HttpGet]
        [Route("ganhadores")]
        public Task<HttpResponseMessage> ListarGanhadores()
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var ganhadores = _megaSenaServico.ListarGanhadores();
                response = Request.CreateResponse(HttpStatusCode.OK, ganhadores);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }


        [HttpPost]
        [Route("sorteio")]
        public Task<HttpResponseMessage> Sortear()
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var sorteio = _megaSenaServico.RodarSorteioDefinindoGanhadores();
                response = Request.CreateResponse(HttpStatusCode.OK, sorteio);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        [HttpGet]
        [Route("sorteio")]
        public Task<HttpResponseMessage> ListarSorteios()
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var sorteios = _megaSenaServico.ListarSorteios();
                response = Request.CreateResponse(HttpStatusCode.OK, sorteios);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }


        [HttpGet]
        [Route("ultimosorteio")]
        public Task<HttpResponseMessage> UltimoSorteios()
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var sorteio = _megaSenaServico.UltimoSorteio();
                response = Request.CreateResponse(HttpStatusCode.OK, sorteio);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }


        protected override void Dispose(bool disposing)
        {

        }
    }
}
