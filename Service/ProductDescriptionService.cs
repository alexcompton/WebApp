using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Core.Data;
using WebApp.Dto;

namespace WebApp.Service
{
    public class ProductDescriptionService : BaseCrudService<ProductDescriptionDto>
    {
        public ProductDescriptionService(ICrudRepo<ProductDescriptionDto> repo) : base(repo) { }

    }
}
