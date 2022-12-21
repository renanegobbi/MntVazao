using System;
using System.ComponentModel;

namespace MntVazao.App.Enums
{
    // tipo de vazão selecionada para plotar o gráfico
    public enum TipoVazao
    {
        [Description("Vazão em Litros por Hora")] // Descrição do parametro
        LitrosPorHora,


        [Description("Vazão em Litros por Hora")] // Descrição do parametro
        LitrosPorDia
    }

    static class TipoVazaoExtension
    {
        public static string getValue(this TipoVazao tipoVazao)
        {
            switch (tipoVazao)
            {
                case TipoVazao.LitrosPorHora:
                    return "0";
                case TipoVazao.LitrosPorDia:
                    return "1";
            }
            return String.Empty;
        }
    }
}