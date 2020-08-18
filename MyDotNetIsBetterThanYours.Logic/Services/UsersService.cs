using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyDotNetIsBetterThanYours.Data;
using MyDotNetIsBetterThanYours.Domain.Models;
using MyDotNetIsBetterThanYours.Logic.Services.Base;


namespace MyDotNetIsBetterThanYours.Logic.Services
{

    public class UsersService : BaseRepository<User>
    {
        public UsersService(AppDbContext db) : base(db)
        {
        }

        public override DbSet<User> DbSet => Db.Users;


        public async Task<List<User>> GetAllUsersWithAppUsersAsync()
        {
            return await Db.Users.Include(x => x.AppUser).ToListAsync();
        }
    }

}