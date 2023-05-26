using Econsult.Domain.Entities;
using Econsult.Infrastructure.DataContext;
using Econsult.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Threading;

namespace Econsult.Infrastructure.Implementations
{
    public class AddressRepository:IAddressRepository
    {
        private readonly AddDbContext _dbContext;

        public AddressRepository(AddDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Address>> GetAddressesByDoctorIdAsync(int doctorId)
        {
            return await _dbContext.Address
                .Where(a => a.DoctorId == doctorId)
                .ToListAsync();
        }

        public async Task<Address> GetAddressByIdAsync(int addressId)
        {
            return await _dbContext.Address.FindAsync(addressId);
        }

        public void AddAddress(Address address)
        {
            _dbContext.Address.Add(address);
        }

        public void DeleteAddress(Address address)
        {
            _dbContext.Address.Remove(address);
        }

        public async Task<bool> DoctorExistsAsync(int doctorId)
        {
            return await _dbContext.Doctor.AnyAsync(d => d.DoctorId == doctorId);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
        
    }

}

