using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hork_Api.Models;
using Hork_Api.Repositories;

namespace Hork_Api.Controllers
{
    [Route("api/exercise")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly ExerciseRepository _exerciseRepository;

        public ExerciseController(
            ExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exercise>>> GetExercises()
        {
            return await _exerciseRepository.GetExercises();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Exercise>> GetExercise(int id)
        {
            var exercise = await _exerciseRepository.GetById(id);

            if (exercise == null)
            {
                return NotFound();
            }

            return exercise;
        }

        [HttpPost]
        public async Task<ActionResult<Exercise>> PostExercises(Exercise exercise)
        {
            await _exerciseRepository.AddExercise(exercise);
            return CreatedAtAction(nameof(GetExercises), new { id = exercise.ExerciseId }, exercise);        
        }
    }
}