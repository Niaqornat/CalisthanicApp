using CalisthenicsApp.Models;
using System.Diagnostics;

namespace CalisthenicsApp.Interfaces
{
    public interface IExerciseRepository
    {
        Task<IEnumerable<Exercise>> GetAll();
        Task<Exercise> GetByIdAsync(int id);
        Task<Exercise> GetByIdAsyncNoTracking(int id);
        Task<IEnumerable<Exercise>> GetAllRacesByCity(string city);
        bool Add(Exercise exercise);
        bool Update(Exercise exercise);
        bool Delete(Exercise exercise);
        bool Save();
    }
}
