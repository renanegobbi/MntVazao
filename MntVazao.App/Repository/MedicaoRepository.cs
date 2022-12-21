using Microsoft.EntityFrameworkCore;
using MntVazao.App.Context;
using MntVazao.App.Interfaces.Repository;
using MntVazao.App.Models;
using System.Linq;

namespace MntVazao.App.Repository
{
    public class MedicaoRepository : IMedicaoRepository
    {
        private readonly MntVazaoContext _context;
        public MedicaoRepository(MntVazaoContext context)
        {
            _context = context;
        }
        public IQueryable<Medicao> ObterTodos() =>  _context.Medicao
                                                      .AsNoTracking()
                                                      .OrderByDescending(m => m.Medicao_DataInicio);

        public IQueryable<Medicao> ObterPorId(int Sensor_ID)
        {
            return from m in _context.Medicao.AsNoTracking()
                   where m.Sensor_ID.ToString().Contains(Sensor_ID.ToString())
                   select m;
        }
    }
}
