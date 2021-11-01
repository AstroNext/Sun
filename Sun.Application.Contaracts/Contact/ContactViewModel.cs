namespace Sun.Application.Contaracts.Contact
{
    public class ContactViewModel
    {
        public long Id { get; set; }
        public string ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string PostCode { get; set; }
        public string Phonenumber { get; set; }
        public bool IsBlock { get; set; }
        public bool IsLogin { get; set; }
        public string CreationTime { get; set; }
    }
}
