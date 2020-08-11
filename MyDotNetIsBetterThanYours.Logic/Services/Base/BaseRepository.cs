using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyDotNetIsBetterThanYours.Data;
using MyDotNetIsBetterThanYours.Domain.Base;
using MyDotNetIsBetterThanYours.Logic.Interfaces.Base;


namespace MyDotNetIsBetterThanYours.Logic.Services.Base
{

    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        // public List<Task> Entities { get; set; }


        public AppDbContext Db { get; set; }
        public abstract DbSet<T> DbSet { get; set; }

        public BaseRepository(AppDbContext db)
        {
            Db = db;
        }


        public async Task<List<T>> GetAllAsync()
        {
            return await Db.Set<T>().Where(x => x.IsActive).ToListAsync();
        }

        public async Task<T> GetByIdAsync(string Id)
        {
            return await Db.Set<T>().FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<string> AddItemAsync(T entity)
        {
            await Db.Set<T>().AddAsync(entity);

            await SaveAsync();

            return entity.Id;
        }

        public async Task<string> UpdateAsync(T entity)
        {
            var exist = await Db.Set<T>().FirstOrDefaultAsync(x => x.Id == entity.Id && x.IsActive);

            if (exist != null)
            {
                exist = entity;
            }

            await SaveAsync();

            return exist.Id;
        }


        public async Task<string> EditAsync(T entity)
        {
            // var exist = await DbSet.Where(x => x.Id == entity.Id && x.IsActive).FirstOrDefaultAsync();
            //
            // if (exist != null)
            // {
            //     exist. = entity;
            // }
            //
            // SaveAsync();
            //
            // return exist.Id;

            throw new NotImplementedException();
        }


        public async Task DeleteAsync(T entity)
        {
            Db.Set<T>().Remove(entity);
            await SaveAsync();
        }

        public async Task HideAsync(T entity)
        {
            var exist = await Db.Set<T>().FirstOrDefaultAsync(x => x.Id == entity.Id && x.IsActive);

            if (exist != null)
            {
                exist.IsActive = false;
                await SaveAsync();
            }
        }

        public async Task UnHideAsync(T entity)
        {
            var exist = await Db.Set<T>().FirstOrDefaultAsync(x => x.Id == entity.Id && x.IsActive == false);

            if (exist != null)
            {
                exist.IsActive = true;
                await SaveAsync();
            }
        }

        public async Task SaveAsync()
        {
            await Db.SaveChangesAsync();
        }
    }

}