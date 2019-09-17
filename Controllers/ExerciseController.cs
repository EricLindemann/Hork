using Hork_Api.Entities;
using Hork_Api.Models;
using Hork_Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hork_Api.Controllers
{
    [Route("api/exercise")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private ExerciseRepository _exerciseRepository;
        public ExerciseController(ExerciseRepository exerciseRepository) {
            _exerciseRepository = exerciseRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExerciseModel>> GetExercise(int id)
        {
            var exerciseModel = new ExerciseModel(await _exerciseRepository.GetById(id));

            if (exerciseModel == null)
            {
                return NotFound();
            }

            return exerciseModel;
        }

    }
}