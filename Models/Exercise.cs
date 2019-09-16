using System.ComponentModel.DataAnnotations.Schema;
using System;
using Hork_Api.Helpers;

namespace Hork_Api.Models
{
    public class Exercise : IAuditable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExerciseId { get; set; }
        public string Name { get; set; }
        public string Notes { get;set; }
        public bool IsSearchable { get; set; }
        public int? CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}