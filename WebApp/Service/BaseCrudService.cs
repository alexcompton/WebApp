using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Core.Data;
using WebApp.Core.Service;

namespace WebApp.Service
{
    public class BaseCrudService<T> : ICrudService<T>
    {
        private readonly ICrudRepo<T> repo;

        public BaseCrudService(ICrudRepo<T> repo)
        {
            this.repo = repo;
        }

        public async Task Add(T t) => await repo.Add(t);
        public async Task Delete(int id) => await repo.Delete(id);
        public async Task<IEnumerable<T>> GetAll() => await repo.GetAll();
        public async Task<T> GetByID(int id) => await repo.GetByID(id);
        public async Task Update(T t) => await repo.Update(t);
    }
}
