namespace DAL.ViewModel
{
    public class AddressDTO
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public int? LocalNumber { get; set; }
    }
}
