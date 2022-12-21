using Microsoft.EntityFrameworkCore;
using MntVazao.App.Interfaces.Repository;
using MntVazao.App.Models;
using MntVazao.App.Context;
using System.Linq;
using System.Threading.Tasks;

namespace MntVazao.App.Repository
{
    public class SensorRepository : ISensorRepository
    {
        private readonly MntVazaoContext _context;
        public SensorRepository(MntVazaoContext context)
        {
            _context = context;
        }

        public IQueryable<Sensor> ObterTodos() => _context.Sensor.AsNoTracking();

        public async Task<Sensor> ObterPorId(string Sensor_ID)
        {
            //Obtém o sensor pelo id
            var saida = await _context.Sensor.AsNoTracking().Include(o => o.Organizacao).Include(sl => sl.SensorLocalizacao)
                .FirstOrDefaultAsync(s => s.Sensor_ID.ToString() == Sensor_ID.ToString());

            return saida;
        }
    }
}
