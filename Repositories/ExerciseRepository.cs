using Hork_Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Hork_Api.Repositories
{
    public class ExerciseRepository
    {
        private HorkContext _context;
        public ExerciseRepository(HorkContext context) 
        {
            _context = context;
            
        }

        public async Task<List<Exercise>> GetExercises() {
            return await _context.Exercises.ToListAsync();
        }

        public async Task<Exercise> GetById(int id) {
            return await _context.Exercises.FindAsync(id);
        }

        public async Task<int> AddExercise(Exercise exercise) {
            _context.Exercises.Add(exercise);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateExercise(Exercise exercise) {
            _context.Entry(exercise).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}