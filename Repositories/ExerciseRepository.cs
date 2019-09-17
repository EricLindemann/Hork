using Hork_Api.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hork_Api.Models.ViewModels;
using System.Linq;

namespace Hork_Api.Repositories
{
    public class ExerciseRepository : Repository<Exercise>
    {
        public ExerciseRepository(HorkContext context)
                : base(context)
        { }
    
        public async Task<ExerciseVM> GetById(int id) {
            return await GetAll()
                .Where(x => x.ExerciseId == id)
                .Include(x => x.Workout)
                .Include(x => x.ExerciseDetail)
                .Select(x => new ExerciseVM(x))
                .SingleOrDefaultAsync();
        }
    }
}