using System.Linq;
using System.Linq.Dynamic.Core;

namespace MntVazao.App.Models.API
{
    public static class MedicaoOrdemExtensions
    {
        public static IQueryable<Medicao> AplicaOrdenacao(this IQueryable<Medicao> query, MedicaoOrdem ordem)
        {
            if ((ordem != null) && (!string.IsNullOrEmpty(ordem.OrdenarPor)))
            {
                query = query.OrderBy(ordem.OrdenarPor);
            }
            return query;

        }
    }

    public class MedicaoOrdem
    {
        public string OrdenarPor { get; set; }
    }
}
