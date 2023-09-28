using Microsoft.AspNetCore.Mvc;
using test.Models.Domain;
using test.Models.Dto;

namespace test.Repositories
{
    public interface IWalkReposities
    {
        public Task<Walks> create(Walks walk);
        public Task<List<Walks>> get(string? FilterOn, string? FilterString, string? sortBy, bool isAsc = true, int pageNumber=1, int pageSize=5);
        public Task<Walks?> getById(Guid id);
        public Task<Walks?> update(Walks walk,Guid id);
        public Task<Walks> delete(Walks walk);
    }
}
