using Lab.Data.Context;
using Lab.Domain.Organizers;
using Lab.Domain.Organizers.Interfaces.Repositories;

namespace Lab.Data.Repositories
{
    public class OrganizerRepository : Repository<Organizer>, IOrganizerRepository
    {
        public OrganizerRepository(LabContext labContext) : base(labContext)
        {
        }
    }
}
