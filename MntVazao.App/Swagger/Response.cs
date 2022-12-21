using System.Collections.Generic;

namespace MntVazao.App.Swagger
{
    public class Response
    {
        /// <summary>
        /// Total de medições
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// Total de páginas
        /// </summary>
        public int TotalPaginas { get; set; }

        /// <summary>
        /// Tamanho da página
        /// </summary>
        public int TamanhoPagina { get; set; }

        /// <summary>
        /// Número da páginas
        /// </summary>
        public int NumeroPagina { get; set; }

        /// <summary>
        /// Lista de medição
        /// </summary>
        public IList<object> Resultado { get; set; }

        /// <summary>
        /// Página anterior
        /// </summary>
        public string Anterior { get; set; }

        /// <summary>
        /// Próxima página
        /// </summary>
        public string Proximo { get; set; }
    }
}
