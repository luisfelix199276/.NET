using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Store.API.Model.Request.Post
{
    public class PostCustomerRequestViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        public DateTime? BirthDate { get; set; }
        public string Rg { get; set; }        
        public string Photograph { get; set; }        
        public string PhoneNumber { get; set; }
        public string MobilePhone { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }        
    }
}
