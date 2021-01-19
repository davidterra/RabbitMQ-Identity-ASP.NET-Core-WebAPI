using System.Threading.Tasks;

namespace Common.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
