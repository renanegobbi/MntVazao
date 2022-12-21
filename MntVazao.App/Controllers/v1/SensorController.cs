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
    [SwaggerTag("Permite a consulta dos sensores.")]
    [Route("api/[Controller]")]
    public class SensorController : ControllerBase
    {
        private readonly ISensorRepository _sensorRepository;

        public SensorController(ISensorRepository sensorRepository)
        {
            _sensorRepository = sensorRepository;
        }

        /// <summary>
        ///     Obtém os sensores baseadas nos parâmetros de consulta.
        /// </summary>
        /// <param name="sensor_id"></param>
        [HttpGet]
        [Route("sensor-obter")]
        [Produces("application/json")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Sensores obtidos com sucesso.", typeof(SensorSaida))]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(SensorSaidaResponseExemplo))]
        public async Task<IActionResult> ListaDeMedicoes(string sensor_id)
        {
            try
            {
                if (sensor_id == null) { return NotFound(); }

                var sensor = await _sensorRepository.ObterPorId(sensor_id);

                if (sensor == null) { return NotFound(); }
                return Ok(sensor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
