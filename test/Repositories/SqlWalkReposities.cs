using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test.data;
using test.Models.Domain;
using test.Models.Dto;

namespace test.Repositories
{
    public class SqlWalkReposities : IWalkReposities
    {
        private readonly WalkDbContext dbContext;

        public SqlWalkReposities(WalkDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Walks> create(Walks walk)
        {
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walks> delete(Walks walk)
        {
            dbContext.Walks.Remove(walk);
            await dbContext.SaveChangesAsync();
            return walk;

        }

        public async Task<List<Walks>> get(string?FilterOn,string? FilterString ,string? sortBy,  bool isAsc = true, int pageNumber=1, int pageSize=5)
        {
            var warker = dbContext.Walks.Include(x => x.Difficulty).Include(x => x.Regions).AsQueryable();
            if(string.IsNullOrWhiteSpace(FilterOn)==false&& string.IsNullOrWhiteSpace(FilterString) == false)
            {
                if(FilterOn.Equals("Name",StringComparison.OrdinalIgnoreCase)) {
                    warker= warker.Where(x => x.Name.Contains(FilterString));
                }
            }
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    warker = isAsc? warker.OrderBy(x=>x.Name):warker.OrderByDescending(x=>x.Name);
                }
            }
            int rs = (pageNumber - 1) * pageSize;
            return await warker.Skip(rs).Take(pageSize).ToListAsync();
            /*return await dbContext.Walks.Include(x=>x.Difficulty).Include(x=>x.Regions).ToListAsync();*/
        }

        public async Task<Walks?> getById(Guid id)
        {
            return await dbContext.Walks.Include(x => x.Difficulty).Include(x => x.Regions).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walks?> update(Walks walk, Guid id)
        {

            var walkerData = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if(walkerData == null)
            {
                return null;
            }
            walkerData.LengthInKm = walk.LengthInKm;
            walkerData.WalkImageUlr = walk.WalkImageUlr;
            walkerData.RegionsId = walk.RegionsId;
            walkerData.DifficultyId = walk.DifficultyId;
            walkerData.Name = walk.Name;
            walkerData.Description= walk.Description;
            await dbContext.SaveChangesAsync();
            return walkerData;
        }

    }
}
