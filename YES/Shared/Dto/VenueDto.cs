namespace YES.Shared.Dto
{
    public class VenueDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public  AddressDto Address { get; set; }
    }
}
