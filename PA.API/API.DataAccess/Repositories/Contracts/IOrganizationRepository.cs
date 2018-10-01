using API.DataObjects.Entities;

namespace API.DataAccess.Repositories.Contracts
{
    public interface IOrganisationRepository : IGenericRepository<Organisations>
    {
        void CreateOrganisation(Organisations organisation);
    }
}
