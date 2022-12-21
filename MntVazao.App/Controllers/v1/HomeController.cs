using Microsoft.AspNetCore.Mvc;
using MntVazao.App.Enums;
using MntVazao.App.Herlpers;
using MntVazao.App.Interfaces.Repository;
using MntVazao.App.Models.API;
using MntVazao.App.Results;
using MntVazao.App.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MntVazao.App.Controllers.v1
{
    public class HomeController : Controller
    {
        private readonly IMedicaoRepository _medicaoRepository;
        private readonly DatatablesHelper _datatablesHelper;
        private readonly MedicaoFiltro _medicaoFiltro;
        private readonly MedicaoOrdem _medicaoOrdem;
        private readonly MedicaoPaginacao _medicaoPagincao;

        public HomeController(IMedicaoRepository medicaoRepository,
                              DatatablesHelper datatablesHelper,
                              MedicaoFiltro medicaoFiltro,
                              MedicaoOrdem medicaoOrdem,
                              MedicaoPaginacao medicaoPaginacao)
        {
            _medicaoRepository = medicaoRepository;
            _datatablesHelper = datatablesHelper;
            _medicaoFiltro = medicaoFiltro;
            _medicaoOrdem = medicaoOrdem;
            _medicaoPagincao = medicaoPaginacao;
        }

        public IActionResult Graficos()
        {
            ViewData["sessao"] = "Gráfico";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ListarGraficos(DateTime? data, string tipoVazao)
        {
            var listaMedicoes = new List<KeyValuePair<int, float>>();

            if (data == null && tipoVazao == null)
                Grafico.CriarGrafico(listaMedicoes);
          
            if (tipoVazao == TipoVazao.LitrosPorHora.getValue())
            {
                Medicao.CriarFiltroPorData(data, tipoVazao, _medicaoFiltro);
                var medicoes = Medicao.ObterMedicoesPorData(_medicaoRepository, _medicaoFiltro);
                var medicoesPorHora = Medicao.AgruparMedicoesPorHora(medicoes, data);
                Grafico.CriarGraficoMedicoesPorHora(medicoesPorHora, listaMedicoes);
            }
            if (tipoVazao == TipoVazao.LitrosPorDia.getValue())
            {
                Medicao.CriarFiltroPorData(data, tipoVazao, _medicaoFiltro);
                var medicoes = Medicao.ObterMedicoesPorMes(_medicaoRepository, data);
                var medicoesPorDia = Medicao.AgruparMedicoesPorDia(medicoes, data);
                Grafico.CriarGraficoMedicoesPorDia(medicoesPorDia, listaMedicoes);
            }

            // Retorna as horas do dia (eixo-x) e as medições em litros (eixo-y)
            return new JsonResult(listaMedicoes);
        }

        public IActionResult Dados()
        {
            return View();
        }

        public IActionResult ListarDados(
             int? sensorId,
             DateTime? medicaoDataInicio,
             DateTime? medicaoDataFim,
             string medicaoLeitura,
             int? medicaoStatus)
        {
            try
            {
                if (!string.IsNullOrEmpty(medicaoLeitura)) { medicaoLeitura = medicaoLeitura.Replace(",", "."); }

                var PaginaIndex = _datatablesHelper.PaginaIndex;
                var PaginaTamanho = _datatablesHelper.PaginaTamanho;
                var OrdenarPor = _datatablesHelper.OrdenarPor;
                var OrdenarSentido = _datatablesHelper.OrdenarSentido;

                _medicaoPagincao.Pagina = PaginaIndex;
                _medicaoPagincao.Tamanho = PaginaTamanho;
                _medicaoOrdem.OrdenarPor = $"{OrdenarPor} {OrdenarSentido}";

                if (sensorId.HasValue)
                    _medicaoFiltro.Sensor_ID = sensorId.ToString();

                if (medicaoDataInicio.HasValue)
                    _medicaoFiltro.Medicao_DataInicio = medicaoDataInicio;

                if (medicaoDataFim.HasValue)
                    _medicaoFiltro.Medicao_DataFim = medicaoDataFim;

                if (!string.IsNullOrEmpty(medicaoLeitura))
                    _medicaoFiltro.Medicao_Leitura = medicaoLeitura;

                if (medicaoStatus.HasValue)
                    _medicaoFiltro.Medicao_Status = medicaoStatus.ToString();

                var lista = _medicaoRepository
                    .ObterTodos()
                    .AplicaFiltro(_medicaoFiltro)
                    .AplicaOrdenacao(_medicaoOrdem);

                var listaPaginada = MedicaoPaginado.From(_medicaoPagincao, lista);

                return new DatatablesResult(_datatablesHelper.Draw,
                                            (int)listaPaginada.Total,
                                            listaPaginada.Resultado.Select(x => new
                                            {
                                                sensor_ID = x.Sensor_ID,
                                                medicao_DataInicio = x.Medicao_DataInicio.ToString("dd/MM/yyyy HH:mm:ss"),
                                                medicao_DataFim = x.Medicao_DataFim.ToString("dd/MM/yyyy HH:mm:ss"),
                                                medicao_Leitura = x.Medicao_Leitura.ToString("F"),
                                                medicao_Status = x.Medicao_Status

                                            }).ToArray());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
