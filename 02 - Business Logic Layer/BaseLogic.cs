using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class BaseLogic : IDisposable
    {
        protected readonly RestaurantContext db = new RestaurantContext();

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
