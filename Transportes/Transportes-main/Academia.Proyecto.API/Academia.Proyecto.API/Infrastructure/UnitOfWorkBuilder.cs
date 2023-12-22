using Academia.Proyecto.API.Infrastructure.TransporteDB;
using Farsiman.Domain.Core.Standard.Repositories;
using Farsiman.Infraestructure.Core.Entity.Standard;
using Microsoft.EntityFrameworkCore;

namespace Academia.Proyecto.API.Infrastructure
{
    public class UnitOfWorkBuilder
    {
        readonly IServiceProvider _serviceProvider;
        public UnitOfWorkBuilder(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IUnitOfWork BuilderProyectoTransporte()
        {
            DbContext dbContext = _serviceProvider.GetService<TransporteSeqpContext>() ?? throw new NullReferenceException();
            return new UnitOfWork(dbContext);
        }
    }
}
