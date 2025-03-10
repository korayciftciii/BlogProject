using AutoMapper;
using Entities.DataTransferObject;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SubscribeMailManager : ISubscribeMailService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public SubscribeMailManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<SubscribeMailDto> CreateOneSubscribeAsync(SubscribeMailDtoForInsertion subscribeDto)
        {
            if (subscribeDto == null)
                throw new ArgumentNullException(nameof(subscribeDto));
            var entity = _mapper.Map<SubscribeMail>(subscribeDto);
            _repositoryManager.SubscribeMail.CreateOneSubscribe(entity);

            await _repositoryManager.SaveAsync();
            return _mapper.Map<SubscribeMailDto>(entity);

        }
    }
}
