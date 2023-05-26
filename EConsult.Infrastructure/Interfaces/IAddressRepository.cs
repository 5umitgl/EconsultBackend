using Econsult.Domain.Entities;


namespace Econsult.Infrastructure.Interfaces
{
    public interface IAddressRepository
    {
        Task<List<Address>> GetAddressesByDoctorIdAsync(int doctorId);
        Task<Address> GetAddressByIdAsync(int addressId);
        void AddAddress(Address address);
        void DeleteAddress(Address address);
        Task<bool> DoctorExistsAsync(int doctorId);
        Task SaveChangesAsync();
    }
}
