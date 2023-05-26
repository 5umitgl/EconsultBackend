using EConsult.Domain.Entities;

namespace Econsult.Domain.Entities
{
    public class DoctorRequest
    {
        public Doctor doctor { get; set; }
        public ICollection<Address>? addresses { get; set; }

        //public Address address { get; set; }
    }
}
