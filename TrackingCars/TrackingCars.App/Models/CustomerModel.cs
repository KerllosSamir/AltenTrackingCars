using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrackingCars.Lib;

namespace TrackingCars.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public List<VehicleModel> Vehicles { get; set; }

        public CustomerModel()
        {
            Vehicles = new List<VehicleModel>();
        }

        public CustomerModel(Customer _Customer, bool isLookup)
        {
            this.Id = _Customer.Id;
            this.Name = _Customer.Name;
            this.Address = _Customer.Address;
            if (!isLookup)
                this.Vehicles = _Customer.Vehicles.Select(v => new VehicleModel(v)).ToList();
        }



    }
}