using Econsult.Domain.Entities;
using Econsult.Infrastructure.DataContext;
using Econsult.Infrastructure.Interfaces;

using EConsult.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Econsult.Infrastructure.Implementations
{
    public class AuthRepository:IAuthRepository
    {
       
            private readonly AddDbContext _dbContext;

            public AuthRepository(AddDbContext dbContext)
            {
                _dbContext = dbContext;
            }

        public static string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
        public NewUser GetUserByEmailAndPassword(string email, string password)
            {
                var encodedPassword = EncodePasswordToBase64(password);
                return _dbContext.NewUser.FirstOrDefault(u => u.Email == email && u.Password == encodedPassword);
            }

            public NewUser GetUserByEmail(string email)
            {
                return _dbContext.NewUser.FirstOrDefault(u => u.Email == email);
            }

            public void AddUser(NewUser user)
            {
                _dbContext.NewUser.Add(user);
            }

        public void AddDoctor(Doctor user)
        {
            _dbContext.Doctor.Add(user);
        }
        public void AddPatient(Patient user)
        {
            _dbContext.Patient.Add(user);
        }
        public Doctor GetDoctorByUserId(int userId)
            {
                return _dbContext.Doctor.FirstOrDefault(d => d.UserId == userId);
            }

            public Patient GetPatientByUserId(int userId)
            {
                return _dbContext.Patient.FirstOrDefault(p => p.UserId == userId);
            }
        public void DeleteDoctor(Doctor doctor)
        {
            _dbContext.Doctor.Remove(doctor);
        }
        public  void DeletePatient(Patient patient)
        {
            _dbContext.Patient.Remove(patient);
        }
        public  void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
        

    }
}
