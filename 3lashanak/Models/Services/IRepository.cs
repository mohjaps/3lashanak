using System.Collections.Generic;
using System.Threading.Tasks;

namespace _3lashanak.Models.Services
{
    public interface IRepository<T>
    {
        public Task<List<T>> GetAll(); 
        public Task<T> GetOne(long Id);
        public bool Add(T model);
        public bool Update(T model);
        public bool Delete(T Id);
    }
}
