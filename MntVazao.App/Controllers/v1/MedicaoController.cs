using Microsoft.AspNetCore.Mvc;
using MntVazao.App.Interfaces.Repository;
using MntVazao.App.Models.API;
using MntVazao.App.Swagger;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Net;

namespace MntVazao.App.Controllers.v1
{
    [ApiController]
    [SwaggerTag("Permite a consulta das medições.")]
    [Route("api/[Controller]")]
    public class MedicaoController : ControllerBase
    {
        private readonly IMedicaoRepository _medicaoRepository;

        public MedicaoController(IMedicaoRepository medicaoRepository)
        {
            _medicaoRepository = medicaoRepository;
        }

        /// <summary>
        ///     Obtém as medições baseadas nos parâmetros de consulta.
        /// </summary>
        /// <param name="filtro"></param>
        /// <param name="ordem"></param>
        /// <param name="paginacao"></param>
        [HttpGet]
        [Route("listar-medicoes")]
        [Produces("application/json")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Medições obtidas com sucesso.", typeof(Response))]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(ListaMedicaoSaidaResponseExemplo))]
        public IActionResult ListaDeMedicoes(
            [FromQuery] MedicaoFiltro filtro,
            [FromQuery] MedicaoOrdem ordem,
            [FromQuery] MedicaoPaginacao paginacao)
        {
            try
            {
                var lista = _medicaoRepository
                    .ObterTodos()
                    .AplicaFiltro(filtro)
                    .AplicaOrdenacao(ordem);

                var listaPaginada = MedicaoPaginado.From(paginacao, lista);

                if (listaPaginada.Resultado.Count == 0)
                {
                    return NotFound();
                }
                return Ok(listaPaginada);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
