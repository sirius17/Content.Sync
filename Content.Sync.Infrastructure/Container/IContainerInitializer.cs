
namespace Content.Sync.Infrastructure
{
    public interface IContainerInitializer
    {
        void Initialize(IDependencyContainer container);
    }
}