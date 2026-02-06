namespace NukeLogin.Src.Shared.Base_DTOs
{
    public record AddressDTO
    {
        public string ZipCode { get; set; }
        public string Region { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string Street { get; set; }
        public string? Number { get; set; }
        public string? Complement { get; set; }
    }
}
