using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hork_Api.Entities;
using System.Linq;


namespace Hork_Api.Repositories
{
    public interface IRepository<TEntity>
    where TEntity : class, IEntity
    {
        IQueryable<TEntity> GetAll();
        
        Task Insert(TEntity entity);
    
        Task Update(TEntity entity);
    }
}