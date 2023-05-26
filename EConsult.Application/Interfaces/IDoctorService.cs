using Econsult.Domain.Entities;
using EConsult.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EConsult.Application.Interfaces
{
    public interface IDoctorService
    {

        Task<IEnumerable<Doctor>> GetAllDoctorsAsync(string searchQuery);
        Task<DoctorRequest> GetDoctorByIdAsync(int id);
        Task UpdateDoctorAsync(int id, Doctor doctor);
    }
}
