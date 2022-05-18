using _3lashanak.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _3lashanak.Models.Services
{
    public class PartnersRepo : IRepository<Partners>
    {
        private readonly ApplicationDbContext context;

        public PartnersRepo(ApplicationDbContext context)
        {
            this.context = context;
        }
        public bool Add(Partners model)
        {
            if (model != null)
            {
                context.Partners.Add(model);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(Partners model)
        {
            if (model == null) return false;
            context.Partners.Remove(model);
            context.SaveChanges();
            return true;
        }

        public async Task<List<Partners>> GetAll()
        {
            return await context.Partners.ToListAsync();
        }

        public async Task<Partners> GetOne(long Id)
        {

            return await context.Partners.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public bool Update(Partners model)
        {
            if (model != null)
            {
                context.Partners.Update(model);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
