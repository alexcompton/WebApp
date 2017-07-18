using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Dto;

namespace WebApp.Core.Data
{
    public interface IAddressRepo : ICrudRepo<AddressDto>
    {
    }
}
