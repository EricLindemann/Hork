using Hork_Api.Entities;
using System;
using Hork_Api.Helpers;

namespace Hork_Api.Entities
{
    public class ExerciseSet : IEntity, IAuditable
    {
        public int ExerciseSetId { get; set; }
        public int ExerciseId { get; set; }
        public int Reps { get; set; }
        public int Weight { get; set; }
        public int OrderId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public virtual Exercise Exercise { get; set; }
        
    }
}