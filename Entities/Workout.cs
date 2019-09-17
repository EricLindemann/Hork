using System.ComponentModel.DataAnnotations.Schema;
using System;
using Hork_Api.Helpers;
using System.Collections.Generic;

namespace Hork_Api.Entities
{
    public class Workout : IEntity, IAuditable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WorkoutId { get; set; }
        public string Name { get; set; }
        public DateTime CompletedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public virtual ICollection<Exercise> ExerciseId { get; set; }
    }
}