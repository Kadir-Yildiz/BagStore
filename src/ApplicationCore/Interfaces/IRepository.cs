using ApplicationCore.Entities;
using Ardalis.Specification;

namespace ApplicationCore.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);

        Task<List<T>> GetAllAsync(); 
        Task<List<T>> GetAllAsync(ISpecification<T> specification); 
    }
}
