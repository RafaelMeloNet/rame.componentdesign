using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using rame.componentdesign.datastore.Data;
using rame.componentdesign.datastore.Internal;
using SimpleInjector;
using System.Diagnostics;

namespace rame.componentdesign.datastore
{
    public class DatastoreFactory : IDisposable
    {
        private readonly Container container = new();
        private bool disposedValue;

        public DatastoreFactory(IConfiguration configuration)
        {
            container.RegisterSingleton(() => configuration ?? throw new ArgumentNullException(nameof(configuration)));

            DbContextOptions<MainDbContext> dbContextOprions = new DbContextOptionsBuilder<MainDbContext>()
                .UseSqlServer(configuration.GetConnectionString("DbOrigem") ?? throw new ArgumentNullException(nameof(configuration)))
#if DEBUG
                .EnableSensitiveDataLogging()
                .LogTo(message => Debug.WriteLine(message), LogLevel.Information)
#endif
                .Options;

            container.RegisterSingleton(() => dbContextOprions);

            container.Register<MainDbContext>(Lifestyle.Singleton);

            container.Register<IDataDomain, DataDomain>();

            container.Verify();
        }

        public IDataDomain DataDomain => container.GetInstance<IDataDomain>();

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
        // ~DatastoreFactory()
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
