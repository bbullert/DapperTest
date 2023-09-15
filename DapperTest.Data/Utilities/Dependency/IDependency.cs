namespace DapperTest.Data.Utilities.Dependency
{
    public interface IDependency
    {
    }

    public interface ITransientDependency : IDependency
    {
    }

    public interface IScopedDependency : IDependency
    {
    }

    public interface ISingletonDependency : IDependency
    {
    }
}
