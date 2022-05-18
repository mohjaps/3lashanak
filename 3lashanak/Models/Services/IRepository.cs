using System.Threading.Tasks;

namespace _3lashanak.Models.Services
{
    public interface IRepository<T>
    {
        public Task GetAll(); 
        public Task<T> GetOne();
        public Task<T> Add(T model);
        public Task<T> Update(T model);
        public Task<T> Delete(long Id);
    }
}
