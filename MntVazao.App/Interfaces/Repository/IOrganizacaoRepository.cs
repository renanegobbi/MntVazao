using MntVazao.App.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MntVazao.App.Interfaces.Repository
{
    public interface IOrganizacaoRepository
    {
        IQueryable<Organizacao> ObterTodos();

        Task<Organizacao> ObterPorId(string Organizacao_ID);
    }
}
