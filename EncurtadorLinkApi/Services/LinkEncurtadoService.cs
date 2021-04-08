using EncurtadorLinkApi.Domain.Entities;
using EncurtadorLinkApi.Domain.Repositories;
using EncurtadorLinkApi.Domain.Services;
using Murmur;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EncurtadorLinkApi.Services
{
    public class LinkEncurtadoService : ILinkEncurtadoService
    {
        private readonly ILinkEncurtadoRepository _linkRepository;
        private readonly IUnitOfWork _unitOfWork;

        public LinkEncurtadoService(ILinkEncurtadoRepository linkRepository, IUnitOfWork unitOfWork)
        {
            _linkRepository = linkRepository;
            _unitOfWork = unitOfWork;
        }

        public string CriarHash(string resource, uint seed = 128)
        {
            HashAlgorithm hashAlgorithm = MurmurHash.Create32(seed: seed);
            byte[] computedHash = hashAlgorithm.ComputeHash(System.Text.Encoding.UTF8.GetBytes(resource));

            StringBuilder sOutput = new StringBuilder(computedHash.Length);

            for (var i = 0; i < computedHash.Length; i++)
            {
                sOutput.Append(computedHash[i].ToString("x2"));
            }

            return sOutput.ToString();
        }

        public Task<IEnumerable<LinkEncurtado>> Get() =>
            _linkRepository.GetAll();
        
        public Task<LinkEncurtado> Get(Guid id) =>
            _linkRepository.GetById(id);

        public async Task<LinkEncurtado> Create(LinkEncurtado link)
        {
            _linkRepository.Add(link);

            var test = await _linkRepository.GetById(link.Id);

            await _unitOfWork.Commit();

            return test;
        }
    }
}