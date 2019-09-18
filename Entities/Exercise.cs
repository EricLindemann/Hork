using System.ComponentModel.DataAnnotations.Schema;
using System;
using Hork_Api.Helpers;
using System.Collections.Generic;

namespace Hork_Api.Entities
{
    public class Exercise : IEntity, IAuditable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExerciseId { get; set; }
        public int WorkoutId { get; set; }
        public int ExerciseDetailId { get; set; }
        public int OrderId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public virtual Workout Workout { get; set; }
        public virtual ExerciseDetail ExerciseDetail { get; set; }
        public virtual ICollection<ExerciseSet> ExerciseSets { get; set; }
    }
}