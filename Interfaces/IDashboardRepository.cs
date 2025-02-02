using CalisthenicsApp.Models;
using System.Diagnostics;

namespace CalisthenicsApp.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<Exercise>> GetAllUserExercises();
        Task<List<Club>> GetAllUserClubs();
        Task<AppUser> GetUserById(string id);
        Task<AppUser> GetByIdNoTracking(string id);
        bool Update(AppUser user);
        bool Save();
    }
}
