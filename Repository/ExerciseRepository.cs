using Microsoft.EntityFrameworkCore;
using CalisthenicsApp.Data;
using CalisthenicsApp.Interfaces;
using CalisthenicsApp.Models;

namespace CalisthenicsApp.Repository
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly ApplicationDbContext _context;

        public ExerciseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Exercise exercise)
        {
            _context.Add(exercise);
            return Save();
        }

        public bool Delete(Exercise exercise)
        {
            _context.Remove(exercise);
            return Save();
        }

        public async Task<IEnumerable<Exercise>> GetAll()
        {
            return await _context.Exercises.ToListAsync();
        }

        public async Task<IEnumerable<Exercise>> GetAllRacesByCity(string city)
        {
            return await _context.Exercises.Where(c => c.Address.City.Contains(city)).ToListAsync();
        }

        public async Task<Exercise> GetByIdAsync(int id)
        {
            return await _context.Exercises.Include(i => i.Address).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Exercise> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Exercises.Include(i => i.Address).AsNoTracking().FirstOrDefaultAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Exercise exercise)
        {
            _context.Update(exercise);
            return Save();
        }
    }
}
