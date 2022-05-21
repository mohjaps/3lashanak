using _3lashanak.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _3lashanak.Models.Services
{
    public class ServicePackegesRepo :IRepository<ServicePackeges>
    {
        private readonly ApplicationDbContext context;

        public ServicePackegesRepo(ApplicationDbContext context)
        {
            this.context = context;
        }
        public bool Add(ServicePackeges model)
        {
            if (model != null)
            {
                context.ServicePackeges.Add(model);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(ServicePackeges model)
        {
            if (model == null) return false;
            context.ServicePackeges.Remove(model);
            context.SaveChanges();
            return true;
        }

        public async Task<List<ServicePackeges>> GetAll()
        {
            return await context.ServicePackeges.ToListAsync();
        }

        public async Task<ServicePackeges> GetOne(long Id)
        {

            return await context.ServicePackeges.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public bool Update(ServicePackeges model)
        {
            if (model != null)
            {
                context.ServicePackeges.Update(model);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
