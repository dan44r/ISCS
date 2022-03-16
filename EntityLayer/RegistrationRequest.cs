using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class RegistrationRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ClientRefNum { get; set; }
        public string Phone { get; set; }
        public string EmailAddress { get; set; }
    } 
}
