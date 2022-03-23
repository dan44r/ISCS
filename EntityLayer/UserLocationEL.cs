namespace EntityLayer
{
    public class UserLocationEL
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
        public string AlsoNotifyName { get; set; }
        public string AlsoNotifyPhone { get; set; }
        public string ExportEIN { get; set; }
        public int PartiesToTransaction { get; set; }
        public string ExportIntermediateConsignee { get; set; }
        public string ExportAddress { get; set; }
        public string ExportCity { get; set; }
        public string ExportPostalCode { get; set; }
        public int ExportCountryId { get; set; }
        public string ExportIntermediateContact { get; set; }
        public string ExportIntermediatePhone { get; set; }
    }
}
