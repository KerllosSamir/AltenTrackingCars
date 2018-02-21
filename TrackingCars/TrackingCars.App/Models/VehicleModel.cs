using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrackingCars.Lib;

namespace TrackingCars.Models
{
    public class VehicleModel
    {
        public int Id { get; set; }
        public string VIN { get; set; }
        public string RegNo { get; set; }
        public int? ConnectionStatus { get; set; } 

        public VehicleModel()
        {

        }
        public VehicleModel(Vehicle _Vehicle)
        {
            this.Id = _Vehicle.Id;
            this.VIN = _Vehicle.VIN;
            this.RegNo = _Vehicle.RegNo;
            this.ConnectionStatus = _Vehicle.ConnectionStatus;
        }

    }
}