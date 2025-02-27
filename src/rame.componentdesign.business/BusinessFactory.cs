using Microsoft.Extensions.Configuration;
using rame.componentdesign.business.Internal;
using rame.componentdesign.datastore;
using SimpleInjector;

namespace rame.componentdesign.business
{
    public class BusinessFactory : IDisposable
    {
        private readonly Container container = new();
        private bool disposedValue;

        public BusinessFactory(IConfiguration configuration)
        {
            container.RegisterSingleton(() => configuration ?? throw new ArgumentNullException(nameof(configuration)));

            container.Register<DatastoreFactory>(Lifestyle.Singleton);

            container.Register<IBusinessDomain, BusinessDomain>();

            container.Verify();
        }

        public IBusinessDomain BusinessDomain => container.GetInstance<IBusinessDomain>();

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    container.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~BusinessFactory()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
