using Entities.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IContactService 
    {
        Task<ContactDto> CreateContactMessage(ContactDtoForInsertion contactDto);
    }
}
