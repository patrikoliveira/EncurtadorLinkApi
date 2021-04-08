using System;
using System.Threading.Tasks;

namespace EncurtadorLinkApi.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
         Task<bool> Commit();
    }
}