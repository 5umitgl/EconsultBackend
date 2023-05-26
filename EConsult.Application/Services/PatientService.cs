using Econsult.Domain.Entities;
using Econsult.Infrastructure.Implementations;
using EConsult.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EConsult.Application.Services
{
    public class PatientService:IPatientService
    {

        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<IEnumerable<Patient>> GetPatientsAsync()
        {
            return await _patientRepository.GetPatientsAsync();
        }

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            return await _patientRepository.GetPatientByIdAsync(id);
        }

        public async Task UpdatePatientAsync(int id, Patient patient)
        {
            var existingPatient = await _patientRepository.GetPatientByIdAsync(id);
            if (existingPatient == null)
            {
                throw new DllNotFoundException("Patient not found.");
            }

            // Update patient properties
            existingPatient.Name = patient.Name;
            // Update other patient properties

            await _patientRepository.UpdatePatientAsync(existingPatient);

        }
        public async Task UploadMedicalRecordAsync(MedicalRecord record, IFormFile documentFile)
        {
            if (documentFile != null && documentFile.Length > 0)
            {
                // Read the file data
                using (var memoryStream = new MemoryStream())
                {
                    await documentFile.CopyToAsync(memoryStream);
                    record.Document = memoryStream.ToArray();
                }
            }

            await _patientRepository.UploadMedicalRecordAsync(record);
        }
    }
}