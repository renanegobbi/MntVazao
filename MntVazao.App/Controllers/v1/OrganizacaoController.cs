using Microsoft.AspNetCore.Mvc;
using MntVazao.App.Interfaces.Repository;
using MntVazao.App.Swagger;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Net;
using System.Threading.Tasks;

namespace MntVazao.App.Controllers.v1
{
    [ApiController]
    [SwaggerTag("Permite a consulta das organizações.")]
    [Route("api/[Controller]")]
    public class OrganizacaoController : ControllerBase
    {
        private readonly IOrganizacaoRepository _organizacaoRepository;

        public OrganizacaoController(IOrganizacaoRepository organizacaoRepository)
        {
            _organizacaoRepository = organizacaoRepository;
        }

        /// <summary>
        ///     Obtém as organizações baseadas nos parâmetros de consulta.
        /// </summary>
        /// <param name="organizacao_id"></param>
        [HttpGet]
        [Route("organizacao-obter")]
        [Produces("application/json")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Organizações obtidas com sucesso.", typeof(OrganizacaoSaida))]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(OrganizacaoSaidaResponseExemplo))]
        public async Task<IActionResult> ObterPorId(string organizacao_id)
        {
            try
            {
                if (organizacao_id == null) { return NotFound(); }

                var organizacao = await _organizacaoRepository.ObterPorId(organizacao_id);

                if (organizacao == null) { return NotFound(); }

                return Ok(organizacao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
