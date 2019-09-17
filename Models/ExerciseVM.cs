using Hork_Api.Entities;

namespace Hork_Api.Models
{
    public class ExerciseModel
    {
        public ExerciseModel() { }
        public ExerciseModel(Exercise exercise) {
            ExerciseId = exercise.ExerciseId;
            ExerciseDetailId = exercise.ExerciseDetailId;
            WorkoutId = exercise.WorkoutId;
            WorkoutName = exercise.Workout.Name;
            Name = exercise.ExerciseDetail.Name;
            IsSearchable = exercise.ExerciseDetail.IsSearchable;
            OrderId = exercise.OrderId;
        }
        public int ExerciseId { get; set; }
        public int ExerciseDetailId { get; set; }
        public int WorkoutId { get; set; }
        public string Name { get; set; }
        public string WorkoutName { get; set; }
        public bool IsSearchable { get; set; }
        public int OrderId { get; set; }
    }
}