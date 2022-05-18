using _3lashanak.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _3lashanak.Models.Services
{
    public class ServiceRepo : IRepository<Service>
    {
        private readonly ApplicationDbContext context;

        public ServiceRepo(ApplicationDbContext context)
        {
            this.context = context;
        }
        public bool Add(Service model)
        {
            if (model != null)
            {
                context.Services.Add(model);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(Service model)
        {
           if(model == null) return false;
           context.Services.Remove(model);
            context.SaveChanges();
            return true;
        }

        public async Task<List<Service>> GetAll()
        {
            return await context.Services.ToListAsync();
        }

        public async Task<Service> GetOne(long Id)
        {
            
            return await context.Services.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public bool Update(Service model)
        {
            if(model != null)
            {
                context.Services.Update(model);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
