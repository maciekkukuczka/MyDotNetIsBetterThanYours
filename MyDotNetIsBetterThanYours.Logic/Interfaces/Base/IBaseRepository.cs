using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyDotNetIsBetterThanYours.Data;
using MyDotNetIsBetterThanYours.Domain.Base;


namespace MyDotNetIsBetterThanYours.Logic.Interfaces.Base
{

    public interface IBaseRepository<T> where T : BaseEntity
    {
        AppDbContext Db { get; set; }

        DbSet<T> DbSet { get; }

        // List<Task> Entities { get; set; }


        Task<List<T>> GetAllAsync();

        Task<T> GetByIdAsync(string Id);

        Task<string> AddItemAsync(T entity);

        Task<string> UpdateAsync(T entity);

        Task<string> EditAsync(T entity);

        Task DeleteAsync(T entity);

        Task HideAsync(T entity);

        Task UnHideAsync(T entity);


        Task SaveAsync();
    }

}