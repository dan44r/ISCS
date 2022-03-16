using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class Carriers
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CarrierName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int StateId { get; set; }
        public string PostalCode { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactFax { get; set; }
        public string ContactEmail { get; set; }
    }
}
