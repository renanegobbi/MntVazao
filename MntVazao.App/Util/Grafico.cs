using MntVazao.App.Interfaces.Repository;
using MntVazao.App.Models;
using MntVazao.App.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using Medicao_ = MntVazao.App.Models.Medicao;

namespace MntVazao.App.Util
{
    public static class Grafico
    {
        public static void CriarGrafico(List<KeyValuePair<int, float>> listaMedicoes)
        {
            for (var hora = 0; hora <= 23; hora++)
            {
                listaMedicoes.Add(new KeyValuePair<int, float>(hora, 0f));
            }
        }

        public static void CriarGraficoMedicoesPorHora(IOrderedEnumerable<IGrouping<int, Medicao_>> medicoesPorHora, List<KeyValuePair<int, float>> listaMedicoes)
        {
            for (var hora = 0; hora <= 23; hora++)
            {
                // Armazena em array as horas que contêm medições
                var arrayDeChaves = medicoesPorHora.Select(m => m.Key).ToArray();
                // Se a hora não contém medição, retorna 0
                if (!arrayDeChaves.Contains(hora))
                {
                    listaMedicoes.Add(new KeyValuePair<int, float>(hora, 0f));
                }
                // Se a hora contém medição, soma as medições contidas na hora
                else
                {
                    var somaPorHora = 0f;
                    var listaHoraAtual = medicoesPorHora.Where(m => m.Key == hora);
                    foreach (var horaAtual in listaHoraAtual)
                    {
                        somaPorHora = horaAtual.Sum(m => m.Medicao_Leitura);
                    }
                    listaMedicoes.Add(new KeyValuePair<int, float>(hora, somaPorHora));
                }
            }
        }

        public static void CriarGraficoMedicoesPorDia(IOrderedEnumerable<IGrouping<int, Medicao_>> medicoesPorDia, List<KeyValuePair<int, float>> listaMedicoes)
        {
            var mes = DateTime.Today.Month;
            var ano = DateTime.Today.Year;
            var quantidadeDias = DateTime.DaysInMonth(ano, mes);

            // Preenche a lista (listaMedicoes) para traçar o gráfico
            for (var dia = 1; dia <= quantidadeDias; dia++)
            {
                // Armazena em array os dias que contêm medições
                var arrayDeChaves = medicoesPorDia.Select(m => m.Key).ToArray();
                // Se o dia não contém medição, retorna 0
                if (!arrayDeChaves.Contains(dia))
                {
                    listaMedicoes.Add(new KeyValuePair<int, float>(dia, 0f));
                }
                // Se o dia contém contém medição, soma as medições contidas no dia
                else
                {
                    var somaPorDia = 0f;
                    var listaDiaAtual = medicoesPorDia.Where(m => m.Key == dia);
                    foreach (var diaAtual in listaDiaAtual)
                    {
                        somaPorDia = diaAtual.Sum(m => m.Medicao_Leitura);
                    }
                    listaMedicoes.Add(new KeyValuePair<int, float>(dia, somaPorDia));
                }
            }
        }
    }
}
