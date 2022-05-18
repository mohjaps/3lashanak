using _3lashanak.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _3lashanak.Models.Services
{
    public class PackagesRepo : IRepository<Packages>
    {
        private readonly ApplicationDbContext context;

        public PackagesRepo(ApplicationDbContext context)
        {
            this.context = context;
        }
        public bool Add(Packages model)
        {
            if (model != null)
            {
                context.Packages.Add(model);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(Packages model)
        {
            if (model == null) return false;
            context.Packages.Remove(model);
            context.SaveChanges();
            return true;
        }

        public async Task<List<Packages>> GetAll()
        {
            return await context.Packages.ToListAsync();
        }

        public async Task<Packages> GetOne(long Id)
        {

            return await context.Packages.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public bool Update(Packages model)
        {
            if (model != null)
            {
                context.Packages.Update(model);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
