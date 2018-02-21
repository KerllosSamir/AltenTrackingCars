using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingCars.Lib
{
    public class VehicleBL : IDisposable
    {
        private AltenChallengeEntities context = new AltenChallengeEntities();
        public void Dispose()
        {
            context.Dispose();
        }
        public List<Vehicle> Search(VehicleSC sc)
        {
            if (sc == null)
            {
                sc = new VehicleSC();
            }

            var q = context.Vehicles.AsQueryable();

            if (sc.Ids != null && sc.Ids.Count > 0)
                q = q.Where(m => sc.Ids.Contains(m.Id));


            if (sc.Id > 0)
                q = q.Where(i => i.Id == sc.Id);

            return q.ToList();
        }

        public Vehicle Find(long p)
        {
            return context.Vehicles.Find(p);
        }
    }
    public class VehicleSC
    {
        public long Id { get; set; }

        public List<int> Ids { get; set; }

        public VehicleSC()
        {
            Ids = new List<int>();

        }
    }
}
