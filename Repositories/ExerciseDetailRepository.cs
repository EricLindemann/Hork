using Hork_Api.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hork_Api.Models.ViewModels;
using System.Linq;


namespace Hork_Api.Repositories
{
    public class ExerciseDetailRepository : Repository<ExerciseDetail>
    {
        public ExerciseDetailRepository(HorkContext context)
            :base(context)
        { }

        public async Task<List<ExerciseDetailVM>> GetExerciseDetails() {
            return await GetAll()
                .Select(x => new ExerciseDetailVM(x))
                .ToListAsync();
        }

        public async Task<ExerciseDetailVM> GetById(int id) {
            return await GetAll()
                .Where(x => x.ExerciseDetailId == id)
                .Select(x => new ExerciseDetailVM(x))
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