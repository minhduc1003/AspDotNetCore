using Microsoft.EntityFrameworkCore;
using test.data;
using test.Models.Domain;
using test.Models.Dto;

namespace test.Repositories
{
    public class SqlRegionsRepositories : IRegionRepositories
    {
        private readonly WalkDbContext dbContext;

        public SqlRegionsRepositories(WalkDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Regions> Create(Regions regionDomainModel)
        {
            await dbContext.Regions.AddAsync(regionDomainModel);
            await dbContext.SaveChangesAsync();
            return regionDomainModel;
        }

        public async Task<Regions> Delete(Regions regionDomainModel)
        {
            dbContext.Regions.Remove(regionDomainModel);
            await dbContext.SaveChangesAsync(); 
            return regionDomainModel;
        }

        public async Task<Regions?> GetById(Guid id)
        {
            return await dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<List<Regions>> GetRegionsAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }

 
    }
}
