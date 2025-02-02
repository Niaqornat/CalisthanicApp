using CalisthenicsApp.Models;
using CalisthenicsApp.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalisthenicsApp.Data;

namespace CalisthenicsApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AppUser>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<AppUser> GetUserById(string id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public bool Add(AppUser user)
        {
            _context.Users.Add(user);
            return Save();
        }

        public bool Update(AppUser user)
        {
            _context.Users.Update(user);
            return Save();
        }

        public bool Delete(AppUser user)
        {
            _context.Users.Remove(user);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        // Sayfalı kullanıcıları getiren metod
        
        public async Task<IEnumerable<AppUser>> GetPagedUsers(int pageIndex, int pageSize)
        {
            return await _context.Users
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        // Toplam kullanıcı sayısını döndüren metod
        public async Task<int> GetTotalUsers()
        {
            return await _context.Users.CountAsync();
        }
    }
}
