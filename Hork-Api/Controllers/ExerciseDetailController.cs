using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hork_Api.Entities;
using Hork_Api.Repositories;
using Hork_Api.Models;

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
        public async Task<ActionResult<IEnumerable<ExerciseDetailModel>>> GetExerciseDetails()
        {
            var exerciseDetails = await _exerciseDetailRepository.GetExerciseDetails();
            return exerciseDetails.Select(x => new ExerciseDetailModel(x)).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExerciseDetailModel>> GetExerciseDetail(int id)
        {
            var exerciseDetailModel = new ExerciseDetailModel(await _exerciseDetailRepository.GetById(id));

            if (exerciseDetailModel == null)
            {
                return NotFound();
            }
            
            return exerciseDetailModel;
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