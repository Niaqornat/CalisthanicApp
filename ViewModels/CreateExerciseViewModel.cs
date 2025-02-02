using CalisthenicsApp.Data.Enum;
using CalisthenicsApp.Models;

namespace CalisthenicsApp.ViewModels
{
    public class CreateExerciseViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }
        public IFormFile Image { get; set; }
        public ExerciseCategory ExerciseCategory { get; set; }
        public string AppUserId { get; set; }
    }
}
