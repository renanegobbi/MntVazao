using NetTopologySuite.Geometries;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MntVazao.App.Models
{
    public class SensorLocalizacao
    {
        [JsonIgnore]
        public int Sensor_ID { get; set; }
        public int Localizacao_ID { get; set; }
        public DateTime Sensor_Localizacao_DataInicOp { get; set; }
        public string Sensor_Localizacao_Descr { get; set; }
        public DateTime? Sensor_Localizacao_DataFimOp { get; set; }

        [JsonIgnore]
        [Column(TypeName = "geography")]
        public Geometry Sensor_Localizacao_Geo { get; set; }
        public double Sensor_Localizacao_Latitude
        {
            get
            {
                return Sensor_Localizacao_Geo.Coordinate.Y;
            }
        }
        public double Sensor_Localizacao_Longitude
        {
            get
            {
                return Sensor_Localizacao_Geo.Coordinate.X;
            }
        }

        [JsonIgnore]
        /* EF Relation */
        public Sensor Sensor { get; set; }
    }
}
