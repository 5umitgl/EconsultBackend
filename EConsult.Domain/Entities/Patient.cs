using System.ComponentModel.DataAnnotations;

namespace Econsult.Domain.Entities
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? BirthDate { get; set; }
        public string? Gender { get; set; }
        public string? BloodGroup { get; set; }

        public string? Street1 { get; set; }
        public string? street2 { get; set; }

        public string? City { get; set; }
        public string? District { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }

        public string? PostalCode { get; set; }
        public string? OtherDetails { get; set; }
        public string? Language { get; set; }
        
        public string? Image { get; set; }

        public int? UserId { get; set; }
       
    }
}
