using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingCars.Lib
{
    public class CustomerBL : IDisposable
    {
        private AltenChallengeEntities context = new AltenChallengeEntities();
        public void Dispose()
        {
            context.Dispose();
        }
        public List<Customer> Search(CustomerSC sc)
        {
            if (sc == null)
            {
                sc = new CustomerSC();
            }

            var q = context.Customers.AsQueryable();

            if (sc.Ids != null && sc.Ids.Count > 0)
                q = q.Where(c => sc.Ids.Contains(c.Id));

            if (sc.ConnectionStatusId.HasValue)
                q = q.Where(c => c.Vehicles.Any(v => v.ConnectionStatus == sc.ConnectionStatusId));

            if (sc.Id.HasValue && sc.Id.Value > 0)
                q = q.Where(c => c.Id == sc.Id);

            return q.ToList();
        }

        public Customer Find(long p)
        {
            return context.Customers.Find(p);
        }
    }
    public class CustomerSC
    {
        public long? Id { get; set; }

        public List<int> Ids { get; set; }

        public int? ConnectionStatusId { get; set; }

        public CustomerSC()
        {
            Ids = new List<int>();

        }
    }
}
