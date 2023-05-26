using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EConsult.Domain.Entities
{
    public class Doctor
    {

        [Key]
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string? BirthDate { get; set; }
        public string? Gender { get; set; }
        public string? BloodGroup { get; set; }
        public string? Qualification { get; set; }
        public string? Specialization { get; set; }
        public int? TotalExperience { get; set; }
        public string? OtherDetails { get; set; }
        public string? Language { get; set; }
        public int? IsApproved { get; set; }
        public string? Image { get; set; }
        public int? UserId { get; set; }
        public int? Fees { get; set; }
    }
}
