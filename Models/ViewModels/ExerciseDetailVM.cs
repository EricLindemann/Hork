using Hork_Api.Models.Entities;
using System;

namespace Hork_Api.Models.ViewModels
{
    public class ExerciseDetailVM
    {
        public ExerciseDetailVM() { }
        public ExerciseDetailVM(ExerciseDetail exerciseDetail) {
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