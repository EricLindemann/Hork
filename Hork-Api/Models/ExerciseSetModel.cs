using Hork_Api.Entities;

namespace Hork_Api.Models
{
    public class ExerciseSetModel
    {
        public ExerciseSetModel() {

        }

        public ExerciseSetModel(ExerciseSet exerciseSet) {
            ExerciseSetId = exerciseSet.ExerciseSetId;
            Reps = exerciseSet.Reps;
            Weight = exerciseSet.Weight;
            OrderId = exerciseSet.OrderId;
        }

        public int ExerciseSetId { get; set; }
        public int Reps { get; set; }
        public int Weight { get; set; }
        public int OrderId { get; set; }
        
    }
}