using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MntVazao.App.Models
{
    public class Organizacao
    {
        public int Organizacao_ID { get; set; }
        public string Organizacao_Nome { get; set; }
        public string Organizacao_Email { get; set; }
        public string Organizacao_Tel { get; set; }
        public string Organizacao_Endereco { get; set; }

        [JsonIgnore]
        /* EF Relations */
        public IEnumerable<Sensor> Sensores { get; set; }
    }
}
