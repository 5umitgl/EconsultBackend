using Econsult.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EConsult.Application.Interfaces
{
    public interface IAddressService
    {
        Task<List<Address>> GetAddressesByDoctorIdAsync(int doctorId);
        Task<Address> GetAddressByIdAsync(int id);
        Task UpdateAddressAsync(int id, Address address);
        Task AddAddressAsync(int doctorId, Address address);
        Task DeleteAddressAsync(int id);
    }

}
