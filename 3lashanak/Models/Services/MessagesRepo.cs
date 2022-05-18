using _3lashanak.Data;
using System.Collections.Generic;
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

        public bool Delete(long Id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Messages>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Messages> GetOne()
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Messages model)
        {
            throw new System.NotImplementedException();
        }
    }
}
