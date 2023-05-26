using System.ComponentModel.DataAnnotations;

namespace Econsult.Domain.Entities
{
    public class Address
    {

        [Key]
        public int AddressId { get; set; }
        public string? Street { get; set; }
        
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }

        public string? PostalCode { get; set; }
        public string? TimeIn { get; set; }
        public string? TimeOut { get; set; }
        public string? DaysAvailable { get; set; }
        public int? DoctorId { get; set; }

        public void UpdateFrom(Address address)
        {
            // Update the address properties as needed
            Street = address.Street;
            City = address.City;
            State = address.State;
            Country = address.Country;
            PostalCode = address.PostalCode;
            TimeIn = address.TimeIn;
            TimeOut = address.TimeOut;
            DaysAvailable = address.DaysAvailable;
        }
    }
}
