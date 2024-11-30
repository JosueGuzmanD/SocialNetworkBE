namespace SocialNetworkBE.Application.Specifications;

public interface ISpecification<T>
{
   Result<T> IsSatisfiedBy(T entity);
}

public interface IAsyncSpecification<T>
{
   Task<Result<T>> IsSatisfiedByAsync(T entity);
}