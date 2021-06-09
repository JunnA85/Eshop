using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Models.Repositories
{
    public class AdminRepository
    {
        private MyContext context = new MyContext();

        public List<Admin> getCredentials(string username, string h_password)
        {
            return this.context.Admin.Where(s => s.username.Equals(username) && s.password.Equals(h_password)).ToList();
        }
        public Admin getAdmin(int id)
        {
            return this.context.Admin.Find(id);
        }

    }
}
