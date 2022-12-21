using MntVazao.App.Models;
using System.Linq;

namespace MntVazao.App.Interfaces.Repository
{
    public interface IMedicaoRepository
    {
        IQueryable<Medicao> ObterTodos();

        IQueryable<Medicao> ObterPorId(int Sensor_ID);
    }
}
