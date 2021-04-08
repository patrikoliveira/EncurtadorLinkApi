using EncurtadorLinkApi.Domain.Entities;
using EncurtadorLinkApi.Domain.Repositories;

namespace EncurtadorLinkApi.Infrastructure.Repositories
{
    public class LinkEncurtadoRepository : MongoBaseRepository<LinkEncurtado>, ILinkEncurtadoRepository
    {
        public LinkEncurtadoRepository(IMongoContext context) : base(context)
        {
        }
    }
}