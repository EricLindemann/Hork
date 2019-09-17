using Hork_Api.Models.Entities;
using Hork_Api.Models.ViewModels;
using Hork_Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hork_Api.Controllers
{
    [Route("api/Exercise")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private ExerciseRepository _exerciseRepository;
        public ExerciseController(ExerciseRepository exerciseRepository) {
            _exerciseRepository = exerciseRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExerciseVM>> GetExercise(int id)
        {
            var exerciseModel = await _exerciseRepository.GetById(id);

            if (exerciseModel == null)
            {
                return NotFound();
            }

            return exerciseModel;
        }

    }
}