using EConsult.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Econsult.Infrastructure.Implementations
{
    public interface IDoctorRepository
    {

        Task<List<Doctor>> GetAllDoctorsAsync(string searchQuery);
        Task<Doctor> GetDoctorByIdAsync(int doctorId);
        Task UpdateDoctorAsync(Doctor doctor);
        
    }
}
