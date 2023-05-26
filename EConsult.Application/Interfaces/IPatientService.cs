using Econsult.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EConsult.Application.Interfaces
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetPatientsAsync();
        Task<Patient> GetPatientByIdAsync(int id);
        Task UpdatePatientAsync(int id, Patient patient);
        Task UploadMedicalRecordAsync(MedicalRecord record, IFormFile documentFile);
    }
}

