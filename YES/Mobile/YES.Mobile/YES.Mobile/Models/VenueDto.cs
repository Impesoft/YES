namespace YES.Mobile.Dto
{
    public class VenueDto : ObservableObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public  AddressDto Address { get; set; }
    }
}
