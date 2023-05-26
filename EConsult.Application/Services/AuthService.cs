using Econsult.Domain.Entities;
using Econsult.Infrastructure.Implementations;
using Econsult.Infrastructure.Interfaces;

using EConsult.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Econsult.Domain.Entities.SignIn;

namespace EConsult.Application.Services
{
    public class AuthService
    {
       
            private readonly IAuthRepository _authRepository;

            public AuthService(IAuthRepository authRepository)
            {
                _authRepository = authRepository;
            }
      
        public async Task<SignInResponse> SignIn(SignInRequest request)
            {
                SignInResponse response = new SignInResponse();
                response.ISuccess = true;
                response.Message = "Successful";
                response.nametag = null;
                response.id = 0;
                response.role = null;
                response.isApproved = null;

                try
                {
                    var user = _authRepository.GetUserByEmailAndPassword(request.Email, request.Password);
                    if (user != null)
                    {
                        response.Message = "Login Successful";
                        response.nametag = user.Name;
                        response.role = user.Role;

                        if (user.Role == "Doctor")
                        {
                            var doctor = _authRepository.GetDoctorByUserId(user.UserId);
                            response.id = doctor.DoctorId;
                            response.isApproved = doctor.IsApproved;
                        }
                        else
                        {
                            var patient = _authRepository.GetPatientByUserId(user.UserId);
                            response.id = patient.PatientId;
                        }
                    }
                    else
                    {
                        response.ISuccess = false;
                        response.Message = "Login Failed";
                    }
                }
                catch (Exception ex)
                {
                    response.ISuccess = false;
                    response.Message = ex.Message;
                }

                return response;
            }

            public async Task<SignUpResponse> SignUp(NewUser user)
            {
                SignUpResponse response = new SignUpResponse();
                response.ISuccess = true;
                response.Message = "Successful";

                try
                {
                    var existingUser = _authRepository.GetUserByEmail(user.Email);
                    if (existingUser != null)
                    {
                        response.ISuccess = false;
                        response.Message = "User already exists";
                        return response;
                    }
                    else
                    {
                        user.Password = AuthRepository.EncodePasswordToBase64(user.Password);
                        _authRepository.AddUser(user);
                        _authRepository.SaveChanges();

                        if (user.Role == "Doctor")
                        {
                            Doctor doctor = new Doctor();
                            doctor.Name = user.Name;
                            doctor.Email = user.Email;
                            doctor.UserId = user.UserId;
                            _authRepository.AddDoctor(doctor);
                        }
                        else if (user.Role == "Patient")
                        {
                            Patient patient = new Patient();
                            patient.Name = user.Name;
                            patient.Email = user.Email;
                            patient.UserId = user.UserId;
                            _authRepository.AddPatient(patient);
                        }

                        _authRepository.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    response.ISuccess = false;
                    response.Message = ex.Message;
                    return response;
                }

                return response;
            }
        public async Task DeleteDoctor(int id)
        {
            var doctor =  _authRepository.GetDoctorByUserId(id);
            if (doctor == null)
            {
                throw new DllNotFoundException($"Doctor with ID {id} not found.");
            }

            _authRepository.DeleteDoctor(doctor);
              _authRepository.SaveChanges();
        }

        public async Task DeletePatient(int id)
        {
            var patient = _authRepository.GetPatientByUserId(id);
            if (patient == null)
            {
                throw new DllNotFoundException($"Patient with ID {id} not found.");
            }

            _authRepository.DeletePatient(patient);
             _authRepository.SaveChanges();
        }

    }
}
