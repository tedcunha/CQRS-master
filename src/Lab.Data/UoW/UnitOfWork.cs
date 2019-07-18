using Lab.Data.Context;
using Lab.Domain.Core.Commands;
using Lab.Domain.Interfaces;

namespace Lab.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LabContext _labContext;
        public UnitOfWork(LabContext labContext)
        {
            _labContext = labContext;
        }
        public CommandResponse Commit()
        {
            var rowsAffected = _labContext.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }
        public void Dispose()
        {
            _labContext.Dispose();
        }
    }
}
