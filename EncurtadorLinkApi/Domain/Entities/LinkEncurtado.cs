using System;

namespace EncurtadorLinkApi.Domain.Entities
{
    public class LinkEncurtado
    {
        public Guid Id { get; private set; }
        public string Domain { get; set; }
        public string Resource { get; set; }
        public string UserId { get; set; }
        public string Hash { get; set; }

        public string UrlEncurtada  { get; set; }

        public LinkEncurtado()
        {
            Id = Guid.NewGuid();
        }
    }
}