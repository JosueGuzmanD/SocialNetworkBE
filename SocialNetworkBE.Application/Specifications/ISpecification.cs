namespace SocialNetworkBE.Application.Specifications;

public interface ISpecification<T>
{
    bool IsSatisfiedBy(T entity);
    string ErrorMessage { get; }
}

public interface IAsyncSpecification<T>
{
    Task<bool> IsSatisfiedByAsync(T entity);
    string ErrorMessage { get; }
}