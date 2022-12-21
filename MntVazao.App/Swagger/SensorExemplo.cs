using MntVazao.App.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;

namespace MntVazao.App.Swagger
{
    public class SensorSaidaResponseExemplo : IExamplesProvider<SensorSaida>
    {
        public SensorSaida GetExamples() => new SensorSaida
        {
            Sensor_ID = 1,
            Sensor_Descricao = "Sensor de vazão de água",
            Sensor_Ativo = true,
            Sensor_Modelo = "YF-S201",
            Sensor_PressaoNominal = 1.75,
            Sensor_PressaoUnidade = "Mpa",
            Sensor_VazaoMin = 1,
            Sensor_VazaoMax = 30,
            Sensor_VazaoUnidade = "L/min",
            Sensor_CodigoUPC = "7899706159258",
            Sensor_Fabricante = "SEA",
            Sensor_FabricantePartNumber = "YF-S201",
            Sensor_DataInicOp = new DateTime(2020, 06, 26, 13, 15, 0),
            Sensor_DataFimOp = null,
            Organizacao = new Organizacao
            {
                Organizacao_ID = 1,
                Organizacao_Nome = "IFES - Campus Vitória",
                Organizacao_Email = "renaneg@hotmail.com",
                Organizacao_Tel = "5527999362442",
                Organizacao_Endereco = "Av. Vitória, 1729 - Jucutuquara, Vitória - ES, 29040-780"
            },
            SensorLocalizacao = new[]{
                new SensorLocalizacaoSaida{
                Localizacao_ID = 1,
                Sensor_Localizacao_DataInicOp = new DateTime(2020,06,27,13,15,0),
                Sensor_Localizacao_Descr = "Dentro da caixa do hidrômetro",
                Sensor_Localizacao_DataFimOp =  null,
                Sensor_Localizacao_Latitude = "-40.3186",
                Sensor_Localizacao_Longitude = "-20.3111"
                }
            }
        };
    }

    public class SensorSaida
    {
        public int Sensor_ID { get; set; }

        public string Sensor_Descricao { get; set; }

        public bool Sensor_Ativo { get; set; }

        public string Sensor_Modelo { get; set; }

        public double? Sensor_PressaoNominal { get; set; }

        public string Sensor_PressaoUnidade { get; set; }

        public double? Sensor_VazaoMin { get; set; }

        public double? Sensor_VazaoMax { get; set; }

        public string Sensor_VazaoUnidade { get; set; }

        public string Sensor_CodigoUPC { get; set; }

        public string Sensor_Fabricante { get; set; }

        public string Sensor_FabricantePartNumber { get; set; }

        public DateTime? Sensor_DataInicOp { get; set; }

        public DateTime? Sensor_DataFimOp { get; set; }

        public Organizacao Organizacao { get; set; }

        public IEnumerable<SensorLocalizacaoSaida> SensorLocalizacao { get; set; }
    }

    public class SensorLocalizacaoSaida
    {
        public int Localizacao_ID { get; set; }
        public DateTime Sensor_Localizacao_DataInicOp { get; set; }
        public string Sensor_Localizacao_Descr { get; set; }
        public DateTime? Sensor_Localizacao_DataFimOp { get; set; }
        public string Sensor_Localizacao_Latitude { get; set; }
        public string Sensor_Localizacao_Longitude { get; set; }
    }
}
