using System;
using System.Linq;

namespace MntVazao.App.Models.API
{
    public static class MedicaoFiltroExtensions
    {
        public static IQueryable<Medicao> AplicaFiltro(this IQueryable<Medicao> query, MedicaoFiltro filtro)
        {
            if (filtro != null)
            {
                //FILTRO POR SENSOR_ID
                if (!string.IsNullOrEmpty(filtro.Sensor_ID))
                {
                    query = query.Where(l => l.Sensor_ID.ToString().Contains(filtro.Sensor_ID));
                }
                //FILTRO POR MEDICAO_DATAINCIO
                if (!string.IsNullOrEmpty(filtro.Medicao_DataInicio.ToString()))
                {
                    query = query.Where(l => l.Medicao_DataInicio.Date == filtro.Medicao_DataInicio.Value.Date);
                }
                //FILTRO POR MEDICAO_DATAFIM
                if (!string.IsNullOrEmpty(filtro.Medicao_DataFim.ToString()))
                {
                    query = query.Where(l => l.Medicao_DataFim == filtro.Medicao_DataFim.Value.Date);
                }
                //FILTRO POR MEDICAO_LEITURA
                if (!string.IsNullOrEmpty(filtro.Medicao_Leitura))
                {
                    query = query.Where(l => l.Medicao_Leitura.ToString().Contains(filtro.Medicao_Leitura));
                }
                //FILTRO POR STATUS
                if (!string.IsNullOrEmpty(filtro.Medicao_Status))
                {
                    query = query.Where(l => l.Medicao_Status.ToString().Contains(filtro.Medicao_Status));
                }
            }
            return query;
        }
    }

    public class MedicaoFiltro
    {
        public string Sensor_ID { get; set; }
        public DateTime? Medicao_DataInicio { get; set; }
        public DateTime? Medicao_DataFim { get; set; }
        public string Medicao_Leitura { get; set; }
        public string Medicao_Status { get; set; }
    }

}
