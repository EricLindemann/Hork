using System.ComponentModel.DataAnnotations.Schema;
using System;
using Hork_Api.Helpers;
using System.Collections.Generic;

namespace Hork_Api.Entities
{
    public class ExerciseDetail : IEntity, IAuditable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExerciseDetailId { get; set; }
        public string Name { get; set; }
        public string Notes { get;set; }
        public bool IsSearchable { get; set; }
        public int? CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}