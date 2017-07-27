using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopDiaryProject.Repository
{
    public interface IGenericRepository<T> : IDisposable where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        T GetSingle(Expression<Func<T, bool>> predicate);
        bool Add(T entity);
        bool AddRange(IEnumerable<T> entity);
        bool Delete(T entity);
        bool Edit(T entity);
        bool Save();

        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(IEnumerable<T> entity);
        Task<bool> DeleteAsync(T entity);
        Task<bool> EditAsync(T entity);
        Task<bool> SaveAsync();
    }
    //public interface IGenericRepository<T> where T : class
    //{

    //    IQueryable<T> GetAll();
    //    T GetSingle(Guid id);
    //    IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
    //    bool Add(T entity);
    //    void Delete(T entity);
    //    void Edit(T entity);
    //}
}
