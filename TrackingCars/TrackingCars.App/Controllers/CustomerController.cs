using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using TrackingCars.Models;
using TrackingCars.Lib;
using TrackingCars.UISearchCriterias;

namespace TrackingCars.Controllers
{
    [Authorize]
    public class CustomerController : ApiController
    {
        // GetCustomers api/Customer
        [HttpPost]
        public List<CustomerModel> GetCustomers(UICustomerSC sc)
        {
            CustomerBL bl = new CustomerBL();
            List<Customer> customerDBList = bl.Search(sc);

            return customerDBList.Select(c => new CustomerModel(c, false)).ToList();
        }


        public List<CustomerModel> GetCustomerLookup()
        {
            CustomerBL bl = new CustomerBL();
            List<Customer> customerDBList = bl.Search(null);

            return customerDBList.Select(c => new CustomerModel(c, true)).ToList();
        }

    }


}
