using System.ComponentModel.DataAnnotations;

namespace Econsult.Domain.Entities
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int AddressId { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public int Duration { get; set; }
        public string? AppointmentStatus { get; set; }
        public string? ReasonForAppointment { get; set; }
        public string? Notes { get; set; }
        public string? Prescription { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}
