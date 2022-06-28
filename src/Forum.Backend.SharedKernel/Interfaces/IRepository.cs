using Ardalis.Specification;

namespace Forum.Backend.SharedKernel.Interfaces
{
    public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
    {
    }


}