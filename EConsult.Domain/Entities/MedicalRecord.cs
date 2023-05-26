using System.ComponentModel.DataAnnotations;

namespace Econsult.Domain.Entities
{
    public class MedicalRecord
    {
        [Key]
        public int RecordId { get; set; }
        public int PatientId { get; set; }
        public int? DoctorId { get; set; }

        public string? RecordType { get; set; }
        public DateTime? Date { get; set; }
        public string? Diagnosis { get; set; }
        public string? Treatments { get; set; }
        public byte[]? Document { get; set; }
    }

}
