using MntVazao.App.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MntVazao.App.Interfaces.Repository
{
    public interface ISensorRepository
    {
        IQueryable<Sensor> ObterTodos();

        Task<Sensor> ObterPorId(string Sensor_ID);
    }
}
