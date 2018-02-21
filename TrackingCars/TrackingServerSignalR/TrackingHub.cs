using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingServerSignalR.Models;

namespace TrackingServerSignalR
{
    public class TrackingHub : Hub
    {
        private object lockobj = new object();

        public void SendVehicleStatus(VehicleModel vehicle)
        {
            Clients.All.UpdateVehicleStatus(vehicle);
        }

        static int counter = 0;
        public override Task OnConnected()
        {
            try
            {
                lock (lockobj)
                {
                    counter = +1;
                }
                Console.WriteLine("Hub OnConnected {0}\n", Context.ConnectionId);
                Console.WriteLine("Connected clients count" + counter);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            try
            {
                lock (lockobj)
                {
                    counter = -1;
                }
                Console.WriteLine("Hub OnDisconnected {0}\n", Context.ConnectionId);
                Console.WriteLine("Connected clients count" + counter);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            return base.OnDisconnected(stopCalled);
        }
    }
}
