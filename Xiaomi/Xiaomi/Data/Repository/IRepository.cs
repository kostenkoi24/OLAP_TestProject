using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xiaomi.Models;

namespace Xiaomi.Data.Repository
{
    public interface IRepository
    {
        IEnumerable<Shops> GetAllItems();

        void ChangeShop(Shops changedItem);

    }
}
