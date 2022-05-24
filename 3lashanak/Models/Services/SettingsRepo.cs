using _3lashanak.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _3lashanak.Models.Services
{
    public class SettingsRepo : IRepository<Settings>
    {
        private readonly ApplicationDbContext context;

        public SettingsRepo(ApplicationDbContext context)
        {
            this.context = context;
        }
        public bool Add(Settings model)
        {
            if (model != null)
            {
                context.Settings.Add(model);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(Settings model)
        {
            if (model == null) return false;
            context.Settings.Remove(model);
            context.SaveChanges();
            return true;
        }

        public async Task<List<Settings>> GetAll()
        {
            return await context.Settings.ToListAsync();
        }

        public async Task<Settings> GetOne(long Id)
        {

            return await context.Settings.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id);
        }

        public bool Update(Settings model)
        {
            if (model != null)
            {
                context.Settings.Update(model);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
