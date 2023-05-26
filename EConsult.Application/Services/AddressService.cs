
using Econsult.Domain.Entities;
using Econsult.Infrastructure.Interfaces;
using EConsult.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EConsult.Application.Services
{
    public class AddressService:IAddressService
    {
       
            private readonly IAddressRepository _addressRepository;

            public AddressService(IAddressRepository addressRepository)
            {
                _addressRepository = addressRepository;
            }

            public async Task<List<Address>> GetAddressesByDoctorIdAsync(int doctorId)
            {
                return await _addressRepository.GetAddressesByDoctorIdAsync(doctorId);
            }

            public async Task<Address> GetAddressByIdAsync(int id)
            {
                var address = await _addressRepository.GetAddressByIdAsync(id);
                if (address == null)
                {
                    throw new DllNotFoundException($"Address with ID {id} not found.");
                }

                return address;
            }

            public async Task UpdateAddressAsync(int id, Address address)
            {
                var existingAddress = await _addressRepository.GetAddressByIdAsync(id);
                if (existingAddress == null)
                {
                    throw new DllNotFoundException($"Address with ID {id} not found.");
                }

                existingAddress.UpdateFrom(address);
                await _addressRepository.SaveChangesAsync();
            }

            public async Task AddAddressAsync(int doctorId, Address address)
            {
                var doctorExists = await _addressRepository.DoctorExistsAsync(doctorId);
                if (!doctorExists)
                {
                    throw new DllNotFoundException($"Doctor with ID {doctorId} not found.");
                }

                var newAddress = new Address
                {
                    DoctorId = doctorId,
                    Street = address.Street,
                    City = address.City,
                    State = address.State,
                    Country = address.Country,
                    PostalCode = address.PostalCode,
                    TimeIn = address.TimeIn,
                    TimeOut = address.TimeOut,
                    DaysAvailable = address.DaysAvailable
                };

                _addressRepository.AddAddress(newAddress);
                await _addressRepository.SaveChangesAsync();
            }

            public async Task DeleteAddressAsync(int id)
            {
                var address = await _addressRepository.GetAddressByIdAsync(id);
                if (address == null)
                {
                    throw new DllNotFoundException($"Address with ID {id} not found.");
                }

                _addressRepository.DeleteAddress(address);
                await _addressRepository.SaveChangesAsync();
            }
        }

    
}
