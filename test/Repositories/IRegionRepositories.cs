using test.Models.Domain;

namespace test.Repositories
{
    public interface IRegionRepositories
    {
        public Task<List<Regions>> GetRegionsAsync();
        public Task<Regions?> GetById(Guid id);
        public Task<Regions> Create(Regions regionDomainModel);
        public Task<Regions> Delete(Regions regionDomainModel);
    }
}
