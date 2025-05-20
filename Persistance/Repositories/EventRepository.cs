using Microsoft.EntityFrameworkCore;
using Persistance.Contexts;
using Persistance.Entities;
using Persistance.Models;
using System.Linq.Expressions;

namespace Persistance.Repositories;

public class EventRepository(DataContext context) : BaseRepository<EventEntity>(context), IEventRepository
{
    /* Both overrides updateded by chatgpt 4o generated code to include packages */
    public override async Task<RepositoryResult<IEnumerable<EventEntity>>> GetAllAsync()
    {
        try
        {
            var entities = await _table
                .Include(x => x.Packages)
                    .ThenInclude(p => p.Package) // Include the actual Package
                .ToListAsync();

            return new RepositoryResult<IEnumerable<EventEntity>>
            {
                Success = true,
                Result = entities
            };
        }
        catch (Exception ex)
        {
            return new RepositoryResult<IEnumerable<EventEntity>>
            {
                Success = false,
                Error = ex.Message
            };
        }
    }

    /* Both overrides updateded by chatgpt 4o generated code to include packages */
    public override async Task<RepositoryResult<EventEntity?>> GetAsync(Expression<Func<EventEntity, bool>> expression)
    {
        try
        {
            var entity = await _table
                .Include(x => x.Packages)
                    .ThenInclude(p => p.Package) // Again, deep include
                .FirstOrDefaultAsync(expression) ?? throw new Exception("Entity not found");

            return new RepositoryResult<EventEntity?>
            {
                Success = true,
                Result = entity
            };
        }
        catch (Exception ex)
        {
            return new RepositoryResult<EventEntity?>
            {
                Success = false,
                Error = ex.Message
            };
        }
    }
    /* Both overrides updateded by chatgpt 4o generated code to include packages */
}
