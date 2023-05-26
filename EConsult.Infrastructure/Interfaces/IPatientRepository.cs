using Econsult.Domain.Entities;
using EConsult.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Econsult.Infrastructure.Implementations
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetPatientsAsync();
        Task<Patient> GetPatientByIdAsync(int id);
        Task UpdatePatientAsync(Patient patient);
        Task UploadMedicalRecordAsync(MedicalRecord record);
       
    }
}
