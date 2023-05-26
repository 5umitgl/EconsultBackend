using Econsult.Domain.Entities;
using EConsult.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Econsult.Infrastructure.Interfaces
{
    public interface IAuthRepository
    {
        public NewUser GetUserByEmailAndPassword(string email, string password);

        public NewUser GetUserByEmail(string email);
        public void AddUser(NewUser user);
        public void AddDoctor(Doctor user);
        public void AddPatient(Patient user);
        public Doctor GetDoctorByUserId(int userId);
        public Patient GetPatientByUserId(int userId);
        public void DeleteDoctor(Doctor doctor);
        public void DeletePatient(Patient patient);
        public void SaveChanges();

    }
}
