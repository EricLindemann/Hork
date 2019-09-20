using Hork_Api.Entities;
using System;

namespace Hork_Api.Models
{
    public class ExerciseDetailModel
    {
        public ExerciseDetailModel() { }
        public ExerciseDetailModel(ExerciseDetail exerciseDetail) {
            ExerciseDetailId = exerciseDetail.ExerciseDetailId;
            Name = exerciseDetail.Name;
            Notes = exerciseDetail.Notes;
            IsSearchable = exerciseDetail.IsSearchable;
            CreatedById = exerciseDetail.CreatedById;
            CreatedOn = exerciseDetail.CreatedOn;
            UpdatedOn = exerciseDetail.UpdatedOn;
        }
        public int ExerciseDetailId { get; set; }
        public string Name { get; set; }
        public string Notes { get;set; }
        public bool IsSearchable { get; set; }
        public int? CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}