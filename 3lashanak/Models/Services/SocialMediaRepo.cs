using _3lashanak.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _3lashanak.Models.Services
{
    public class SocialMediaRepo : IRepository<SocialMedia>
    {
        private readonly ApplicationDbContext context;

        public SocialMediaRepo(ApplicationDbContext context)
        {
            this.context = context;
        }
        public bool Add(SocialMedia model)
        {
            if (model != null)
            {
                context.SocialMedia.Add(model);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(SocialMedia model)
        {
            if (model == null) return false;
            context.SocialMedia.Remove(model);
            context.SaveChanges();
            return true;
        }

        public async Task<List<SocialMedia>> GetAll()
        {
            return await context.SocialMedia.ToListAsync();
        }

        public async Task<SocialMedia> GetOne(long Id)
        {

            return await context.SocialMedia.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public bool Update(SocialMedia model)
        {
            if (model != null)
            {
                context.SocialMedia.Update(model);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
