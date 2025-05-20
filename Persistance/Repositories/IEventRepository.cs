using Persistance.Entities;
using Persistance.Models;
using System.Linq.Expressions;

namespace Persistance.Repositories;

public interface IEventRepository : IBaseRepository<EventEntity>
{
}