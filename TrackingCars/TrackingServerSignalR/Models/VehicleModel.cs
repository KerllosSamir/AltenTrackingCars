using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingServerSignalR.Models
{
    public class VehicleModel
    {
        public string RegNo { get; set; }

        /// <summary>
        /// 0 means Disconnectd
        /// 1 means Connected
        /// </summary>
        public int ConnectioStatus { get; set; }
    }


}
