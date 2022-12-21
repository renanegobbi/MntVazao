using System;

namespace MntVazao.App.Models
{
    public class Medicao
    {
        public int Sensor_ID { get; set; }
        public DateTime Medicao_DataInicio { get; set; }
        public DateTime Medicao_DataFim { get; set; }
        public float Medicao_Leitura { get; set; }
        public Byte Medicao_Status { get; set; }
    }
}


