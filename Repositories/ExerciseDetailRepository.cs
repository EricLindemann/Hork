using Hork_Api.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace Hork_Api.Repositories
{
    public class ExerciseDetailRepository : Repository<ExerciseDetail>
    {
        public ExerciseDetailRepository(HorkContext context)
            :base(context)
        { }

        public async Task<List<ExerciseDetail>> GetExerciseDetails() {
            return await GetAll()
                .ToListAsync();
        }

        public async Task<ExerciseDetail> GetById(int id) {
            return await GetAll()
                .Where(x => x.ExerciseDetailId == id)
                .SingleOrDefaultAsync();
        }

        public async Task AddExerciseDetail(ExerciseDetail exerciseDetail) {
            await Insert(exerciseDetail);
        }

        public async Task UpdateExerciseDetail(ExerciseDetail exerciseDetail) {
            await Update(exerciseDetail);
        }
    }
}