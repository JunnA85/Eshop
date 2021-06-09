using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Models.Repositories
{
    public class MessageRepository
    {
        private MyContext context = new MyContext();

        public List<Message> findAll()
        {
            return this.context.Message.ToList();
        }
        public Message FindById(int id)
        {
            return this.context.Message.Find(id);
        }
        public void Insert(Message Message)
        {
            this.context.Add(Message);
            this.context.SaveChanges();
        }
    }
}
