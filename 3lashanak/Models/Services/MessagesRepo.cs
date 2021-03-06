using _3lashanak.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3lashanak.Models.Services
{
    public class MessagesRepo : IRepository<Messages>
    {
        private readonly ApplicationDbContext context;

        public MessagesRepo(ApplicationDbContext context)
        {
            this.context = context;
        }
        public bool Add(Messages model)
        {
            if (model != null)
            {
                context.Messages.Add(model);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(Messages model)
        {
           if(model == null) return false;
           context.Messages.Remove(model);
            context.SaveChanges();
            return true;
        }

        public async Task<List<Messages>> GetAll()
        {
            return await context.Messages.ToListAsync();
        }

        public async Task<Messages> GetOne(long Id)
        {
            
            return await context.Messages.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public bool Update(Messages model)
        {
            if(model != null)
            {
                context.Messages.Update(model);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
