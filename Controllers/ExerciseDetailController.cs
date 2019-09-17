using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hork_Api.Models.Entities;
using Hork_Api.Repositories;
using Hork_Api.Models.ViewModels;

namespace Hork_Api.Controllers
{
    [Route("api/exerciseDetail")]
    [ApiController]
    public class ExerciseDetailController : ControllerBase
    {
        private readonly ExerciseDetailRepository _exerciseDetailRepository;

        public ExerciseDetailController(
            ExerciseDetailRepository exerciseDetailRepository)
        {
            _exerciseDetailRepository = exerciseDetailRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExerciseDetailVM>>> GetExerciseDetails()
        {
            return await _exerciseDetailRepository.GetExerciseDetails();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExerciseDetailVM>> GetExerciseDetail(int id)
        {
            var exerciseDetailVM = await _exerciseDetailRepository.GetById(id);

            if (exerciseDetailVM == null)
            {
                return NotFound();
            }
            
            return exerciseDetailVM;
        }

        [HttpPost]
        public async Task<ActionResult<ExerciseDetail>> PostExerciseDetails(ExerciseDetail exerciseDetail)
        {
            await _exerciseDetailRepository.AddExerciseDetail(exerciseDetail);
            return CreatedAtAction(nameof(GetExerciseDetails), new { id = exerciseDetail.ExerciseDetailId }, exerciseDetail);        
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutExerciseDetail(long id, ExerciseDetail exerciseDetail)
        {
            if (id != exerciseDetail.ExerciseDetailId)
            {
                return BadRequest();
            }
            await _exerciseDetailRepository.UpdateExerciseDetail(exerciseDetail);
            return NoContent();
        }
    }
}