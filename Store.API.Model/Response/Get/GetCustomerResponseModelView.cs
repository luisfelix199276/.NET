using System;
using System.Collections.Generic;
using System.Text;

namespace Store.API.Model.Response.Get
{
    public class GetCustomerResponseModelView
    {
        public Guid IdCustomer { get; set; }
        public string Name { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public DateTime? BirthDate { get; set; }
        //public string Age {
        //    public string Get() { return 

        //}
        //}
        public string Photograph { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilePhone { get; set; }            
    }
}
