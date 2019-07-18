using Lab.Domain.Core.Commands;
using System;

namespace Lab.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
