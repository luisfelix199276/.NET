using Dapper.Contrib.Extensions;
using System;

namespace Store.Core.Entity.Entities
{
    [Table("Customer")]
    public class Customers
    {
        [Key]
        public long Id { get; set; }
        public Guid GuidCustomer { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }        
        public string Name { get; set; }
        public string Photograph { get; set; }
        public DateTime? BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilePhone { get; set; }        
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool Active { get; set; }        
    }
}
