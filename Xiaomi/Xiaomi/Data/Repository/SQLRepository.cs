using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xiaomi.Models;

namespace Xiaomi.Data.Repository
{
    public class SQLRepository : IRepository
    {
        private readonly DB _context;

        public SQLRepository(DB context)
        {
            _context = context;
        }

        public void ChangeShop(Shops changedItem)
        {
            var item = _context.shops.Attach(changedItem);
            item.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            _context.SaveChanges();

               
        }

        public IEnumerable<Shops> GetAllItems()
        {
            return _context.shops;
        }
    }
}
