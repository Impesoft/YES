namespace YES.Shared.Dto
{
    public class VenueDto
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public virtual AddressDto Address { get; set; }
    }
}
