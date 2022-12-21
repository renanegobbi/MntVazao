using MntVazao.App.Interfaces.Repository;
using MntVazao.App.Models;
using MntVazao.App.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using Medicao_ = MntVazao.App.Models.Medicao;

namespace MntVazao.App.Util
{
    public static class Medicao
    {
        public static void CriarFiltroPorData(DateTime? data, string tipoVazao, MedicaoFiltro _medicaoFiltro)
        {
            if (data == null && tipoVazao == null) { data = DateTime.Now; tipoVazao = "0"; }
            if (data == null && tipoVazao != null) { data = DateTime.Now; }

            // Cria uma lista com chave e valor de hora do dia e soma de medições correspondente esta hora
            var listaMedicoes = new List<KeyValuePair<int, float>>();
            var diaSelecionado = data?.Day;
            var mesSelecionado = data?.Month;
            var anoSelecionado = data?.Year;
            var mes = DateTime.Today.Month;
            var ano = DateTime.Today.Year;
            var quantidadeDias = DateTime.DaysInMonth(ano, mes);
            var horas = new List<int>();
            for (var hora = 0; hora <= 23; hora++) { horas.Add(hora); }
            var dias = new List<int>();
            for (var dia = 1; dia <= quantidadeDias; dia++) { dias.Add(dia); }

            // Se houver data selecionada
            if (data.HasValue)
                _medicaoFiltro.Medicao_DataInicio = data;
            else
                _medicaoFiltro.Medicao_DataInicio = DateTime.Now;
        }

        public static IEnumerable<Medicao_> ObterMedicoesPorData(IMedicaoRepository _medicaoRepository, MedicaoFiltro _medicaoFiltro)
        {
            // Filtra as medições pela data selecionada
            var medicoes = _medicaoRepository
                .ObterTodos()
                .AplicaFiltro(_medicaoFiltro)
                .OrderByDescending(x => x.Medicao_DataInicio).AsEnumerable();

            return medicoes;
        }

        public static IEnumerable<Medicao_> ObterMedicoesPorMes(IMedicaoRepository _medicaoRepository, DateTime? data)
        {
            // Filtra as medições pelo mês da data selecionada
            var medicoes = _medicaoRepository
                .ObterTodos()
                .Where(x => x.Medicao_DataInicio.Month == data.Value.Month).AsEnumerable();

            return medicoes;
        }

        public static IOrderedEnumerable<IGrouping<int, Medicao_>> AgruparMedicoesPorHora(IEnumerable<Medicao_> medicoes, DateTime? data)
        {
            // Agrupa as medições por cada hora da data selecionada
            var queryPorHora =
                    from medicao in medicoes
                    where medicao.Medicao_DataInicio.Date.ToString() == data.Value.Date.ToString()
                    group medicao by medicao.Medicao_DataInicio.Hour into newGroup
                    orderby newGroup.Key
                    select newGroup;

            return queryPorHora;
        }

        public static IOrderedEnumerable<IGrouping<int, Medicao_>> AgruparMedicoesPorDia(IEnumerable<Medicao_> medicoes, DateTime? data)
        {
            // Agrupa as medições por cada dia do mês selecionado
            var queryPorDia =
                    from medicao in medicoes
                    where medicao.Medicao_DataInicio.Date.Month.ToString() == data?.Month.ToString()
                    group medicao by medicao.Medicao_DataInicio.Day into newGroup
                    orderby newGroup.Key
                    select newGroup;

            return queryPorDia;
        }
    }
}
