using Hork_Api.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Hork_Api.Repositories
{
    public class ExerciseRepository : Repository<Exercise>
    {
        public ExerciseRepository(HorkContext context)
                : base(context)
        { }
    
        public async Task<Exercise> GetById(int id) {
            return await GetAll()
                .Where(x => x.ExerciseId == id)
                .Include(x => x.Workout)
                .Include(x => x.ExerciseDetail)
                .Include(x => x.ExerciseSets)
                .SingleOrDefaultAsync();
        }
    }
}