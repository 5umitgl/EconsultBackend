using Econsult.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Econsult.Domain.Entities.SignIn;

namespace EConsult.Application.Interfaces
{
    public interface IAuthService
    {
        Task<SignInResponse> SignIn(SignInRequest request);
        Task<SignUpResponse> SignUp(NewUser user);
        Task DeleteDoctor(int id);
        Task DeletePatient(int id);
    }

}
