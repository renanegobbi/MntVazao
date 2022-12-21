using Swashbuckle.AspNetCore.Filters;
using System;

namespace MntVazao.App.Swagger
{
    public class ListaMedicaoSaidaResponseExemplo : IExamplesProvider<Response>
    {
        public Response GetExamples() => new Response
        {
            Total = 6,
            TotalPaginas = 3,
            TamanhoPagina = 2,
            NumeroPagina = 1,
            Resultado = new[]{
                new MedicaoSaida{
                    Sensor_ID = 1,
                    Medicao_DataInicio = "2021-10-17T07:45:13",
                    Medicao_DataFim = "2021-10-17T08:00:17",
                    Medicao_Leitura = 1.78f,
                    Medicao_Status = 0
                },
                new MedicaoSaida{
                    Sensor_ID = 1,
                    Medicao_DataInicio = "2021-10-17T07:30:08",
                    Medicao_DataFim = "2021-10-17T07:45:12",
                    Medicao_Leitura = 0,
                    Medicao_Status = 0
                }
            },
            Anterior = "",
            Proximo = "medicoes?pagina=2&tamanho=2"
        };
    }

    public class MedicaoSaida
    {
        public int Sensor_ID { get; set; }
        public String Medicao_DataInicio { get; set; }
        public String Medicao_DataFim { get; set; }
        public float Medicao_Leitura { get; set; }
        public Byte Medicao_Status { get; set; }
    }
}
