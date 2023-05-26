using Econsult.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Econsult.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Econsult.Infrastructure.Implementations
{
    public  class PatientRepository:IPatientRepository
    {
       
            private readonly AddDbContext _dbContext;

            public PatientRepository(AddDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<IEnumerable<Patient>> GetPatientsAsync()
            {
                return await _dbContext.Patient.ToListAsync();
            }

            public async Task<Patient> GetPatientByIdAsync(int id)
            {
                return await _dbContext.Patient.FirstOrDefaultAsync(u => u.UserId == id);
            }

            public async Task UpdatePatientAsync(Patient patient)
            {
                _dbContext.SaveChanges();
                await Task.CompletedTask;
            }
        
            public async Task UploadMedicalRecordAsync(MedicalRecord record)
            {
                _dbContext.MedicalRecord.Add(record);
                await _dbContext.SaveChangesAsync();
            }
    }
}

