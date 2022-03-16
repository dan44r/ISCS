using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
   public class WarehouseLocationEL
    {
       public int Id { get; set; }
       public int UserId { get; set; }
       public string CompanyName { get; set; }
       public string Address { get; set; }
       public string City { get; set; }
       public int StateId { get; set; }
       public string PostalCode { get; set; }
       public int CountryId { get; set; }
       public string ContactName { get; set; }
       public string ContactPhone { get; set; }
       public string ContactFax { get; set; }
       public string ContactEmail { get; set; }
    }
}
