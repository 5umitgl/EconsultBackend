
using Econsult.Domain.Entities;
using Econsult.Infrastructure.Implementations;
using Econsult.Infrastructure.Interfaces;

using EConsult.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EConsult.Application.Services
{
    public class DoctorService
    {
       
            private readonly IDoctorRepository _doctorRepository;
            private readonly IAddressRepository _addressRepository;

            public DoctorService(IDoctorRepository doctorRepository, IAddressRepository addressRepository)
            {
                _doctorRepository = doctorRepository;
                _addressRepository = addressRepository;
            }

            public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync(string searchQuery)
            {
                return await _doctorRepository.GetAllDoctorsAsync(searchQuery);
            }

            public async Task<DoctorRequest> GetDoctorByIdAsync(int id)
            {
                var doctor = await _doctorRepository.GetDoctorByIdAsync(id);
                if (doctor == null)
                {
                    throw new DllNotFoundException("Doctor not found.");
                }

                var addresses = await _addressRepository.GetAddressesByDoctorIdAsync(id);

                return new DoctorRequest
                {
                    doctor = doctor,
                    addresses = addresses
                };
            }

            public async Task UpdateDoctorAsync(int id, Doctor doctor)
            {
                var existingDoctor = await _doctorRepository.GetDoctorByIdAsync(id);
                if (existingDoctor == null)
                {
                    throw new DllNotFoundException("Doctor not found.");
                }

                // Update Doctor properties
                existingDoctor.Name = doctor.Name;
                existingDoctor.Email = doctor.Email;
                existingDoctor.BirthDate = doctor.BirthDate;
                existingDoctor.Phone = doctor.Phone;
                existingDoctor.Gender = doctor.Gender;
                existingDoctor.BloodGroup = doctor.BloodGroup;
                existingDoctor.Qualification = doctor.Qualification;
                existingDoctor.Specialization = doctor.Specialization;
                existingDoctor.TotalExperience = doctor.TotalExperience;
                existingDoctor.OtherDetails = doctor.OtherDetails;
                existingDoctor.Language = doctor.Language;
                existingDoctor.Image = doctor.Image;
                existingDoctor.Fees = doctor.Fees;

                await _doctorRepository.UpdateDoctorAsync(existingDoctor);
            }
        

    }
}
