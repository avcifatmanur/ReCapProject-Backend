using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.IOC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection collection);
    }
}
