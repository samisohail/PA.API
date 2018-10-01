using API.DataAccess.DataContext;
using API.DataAccess.Repositories.Contracts;
using API.DataObjects.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.DataAccess.Repositories
{
    public class OrganisationRepository : GenericRepository<Organisations>, IOrganisationRepository
    {
        private readonly IPA24Context _database;
        public OrganisationRepository(IPA24Context database) : base (database)
        {
            _database = database;
        }
        public void CreateOrganisation(Organisations organisation)
        {
            Add(organisation);
        }
    }
}
