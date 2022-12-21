using Microsoft.EntityFrameworkCore;
using MntVazao.App.Interfaces.Repository;
using MntVazao.App.Models;
using MntVazao.App.Context;
using System.Linq;
using System.Threading.Tasks;

namespace MntVazao.App.Repository
{
    public class OrganizacaoRepository : IOrganizacaoRepository
    {
        private readonly MntVazaoContext _context;
        public OrganizacaoRepository(MntVazaoContext context)
        {
            _context = context;
        }
        public IQueryable<Organizacao> ObterTodos() => _context.Organizacao.AsNoTracking();

        public async Task<Organizacao> ObterPorId(string Organizacao_ID)
        {
            //Obtém a organização pelo id
            var saida = await _context.Organizacao.AsNoTracking()
                .FirstOrDefaultAsync(o => o.Organizacao_ID.ToString() == Organizacao_ID.ToString());

            return saida;
        }
    }
}
