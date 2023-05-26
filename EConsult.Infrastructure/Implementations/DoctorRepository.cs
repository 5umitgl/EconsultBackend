
using Econsult.Infrastructure.DataContext;
using EConsult.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Econsult.Infrastructure.Implementations
{
    // Doctor Repository Implementation
    public class DoctorRepository : IDoctorRepository
    {
        private readonly AddDbContext _dbContext;

        public DoctorRepository(AddDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Doctor>> GetAllDoctorsAsync(string searchQuery)
        {
            if (searchQuery != null)
            {
                return await _dbContext.Doctor
            .Where(d => d.Specialization.ToLower().Contains(searchQuery.ToLower()) || d.Name.ToLower().Contains(searchQuery.ToLower()))
            .ToListAsync();

            }
            return await _dbContext.Doctor.ToListAsync();
        }

        public async Task<Doctor> GetDoctorByIdAsync(int doctorId)
        {
            return await _dbContext.Doctor.FindAsync(doctorId);
        }

        public async Task UpdateDoctorAsync(Doctor doctor)
        {
            _dbContext.Doctor.Update(doctor);
            await _dbContext.SaveChangesAsync();
        }

        // Implement other methods
    }
}
