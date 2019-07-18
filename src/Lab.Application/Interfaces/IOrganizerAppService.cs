using Lab.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.Application.Interfaces
{
    public interface IOrganizerAppService : IDisposable
    {
        void Register(OrganizerViewModel organizerViewModel);
    }
}
