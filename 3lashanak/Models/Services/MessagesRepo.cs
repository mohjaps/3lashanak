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
            throw new System.NotImplementedException();
        }

        public bool Delete(Messages model)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Messages>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Messages> GetOne(long Id)
        {
            
            return await context.Messages.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public bool Update(Messages model)
        {
            throw new System.NotImplementedException();
        }
    }
}
