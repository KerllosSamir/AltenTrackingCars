using System;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using System.Collections.Generic;
using TrackingServerSignalR.Models;

namespace TrackingServerSignalR
{
    class Program
    {
       static void Main(string[] args)
        {

            List<String> Vehicles = new List<string>() { "ABC123", "DEF456", "GHI789", "JKL012", "MNO345", "PQR678", "STU901" };

            string url = "http://localhost:8089";
            using (WebApp.Start(url))
            {
                Console.WriteLine("Server running on {0}", url);
                while (true)
                {
                    System.Threading.Thread.Sleep(6000);

                    IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<TrackingHub>();

                    //Send random status
                    Random randomStatus = new Random();

                    foreach (string car in Vehicles)
                    {
                        VehicleModel model = new VehicleModel();
                        model.RegNo = car;
                        model.ConnectioStatus = GenerateDigit(randomStatus);
                        hubContext.Clients.All.SendVehicleStatus(model);

                        System.Threading.Thread.Sleep(3000);
                    }

                    Console.WriteLine("Server Sending Vehicle Status\n");
                }

            }
        }

       static int GenerateDigit(Random rng)
       {

           return rng.Next(2);
       }
    }
}
