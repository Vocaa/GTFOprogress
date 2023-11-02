using Blazored.LocalStorage;

namespace GTFOprogress.Services
{
    public class LocalStorageServiceFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public LocalStorageServiceFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ILocalStorageService Create()
        {
            return _serviceProvider.GetRequiredService<ILocalStorageService>();
        }
    }
}
