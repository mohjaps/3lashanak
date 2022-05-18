using _3lashanak.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _3lashanak.Models.Services
{
    public class PackagesRepo : IRepository<Packages>
    {
        private readonly ApplicationDbContext _context;
        public PackagesRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Packages model)
        {
            if(model != null)
            {
                _context.Packages.Add(model);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public  bool Delete(long Id)
        {
            if(Id != 0)
            {
                var data = _context.Packages.Find(Id);
                _context.Packages.Remove(data);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
         
        }

        public async Task<List<Packages>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Packages> GetOne()
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Packages model)
        {
            throw new System.NotImplementedException();
        }
    }
}
