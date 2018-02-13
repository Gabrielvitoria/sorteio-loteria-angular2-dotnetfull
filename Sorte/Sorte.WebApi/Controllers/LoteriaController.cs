using Sorte.Domain.ContextMega.Contracts.Services;
using Sorte.WebApi.DTO.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Sorte.WebApi.Controllers
{
  
    public class LoteriaController : ApiController
    {

        public LoteriaController()
        {
        }


        private IMegaSenaService _megaSena;
        public LoteriaController(IMegaSenaService megaSena)
        {
            _megaSena = megaSena;
        }



        [HttpPost]
        [Route("aposta")]
        public Task<HttpResponseMessage> Criar(CartaoApostaRequest request)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var aposta = _megaSena.CriarCartaoAposta(request.Surpresinha, request.NomeApostador, request.NomeApostador);
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
                var aposta = _megaSena.ListarApostas();
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
                var ganhadores = _megaSena.ListarGanhadores();
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
        [Route("sortear")]
        public Task<HttpResponseMessage> Sortear()
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var sorteio = _megaSena.CriarSorteioLoteria();
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

        [HttpPost]
        [Route("sorteios")]
        public Task<HttpResponseMessage> ListarSorteios()
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var sorteios = _megaSena.ListarSorteios();
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

        protected override void Dispose(bool disposing)
        {
            _megaSena.Dispose();
        }
    }
}