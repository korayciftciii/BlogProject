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
   public class ContactManager :IContactService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public ContactManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ContactDto> CreateContactMessage(ContactDtoForInsertion contactDto)
        {
            if (contactDto == null)
               throw new ArgumentNullException(nameof(contactDto));
            var entity=_mapper.Map<Contact>(contactDto);
            _repositoryManager.Contact.CreateMessage(entity);
            await _repositoryManager.SaveAsync();
            return _mapper.Map<ContactDto>(entity);
        }
    }
}
