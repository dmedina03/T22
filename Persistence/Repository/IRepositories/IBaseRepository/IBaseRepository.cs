using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository.IRepositories.IBaseRepository
{
    public interface IBaseRepository<TId, TEntity>: IDisposable 
        where TId : struct 
        where TEntity : class 
    {
        /// <summary>
        /// Método asincrono para crear un nuevo objeto
        /// </summary>
        /// <param name="entity"></param>
        Task AddAsync(TEntity entity);
        /// <summary>
        /// Método para crear un arreglo de objetos
        /// </summary>
        /// <param name="entities"></param>
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        /// <summary>
        /// Determina de forma asincrónica si algún elemento de una secuencia cumple una condición.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? filter = null);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<int> CountAsync(Expression<Func<TEntity, bool>>? filter = null);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(TEntity entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(TId Id);
        /// <summary>
        /// Método asincrono para buscar un objeto por su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> FindByIdAsync(TId id);
        /// <summary>
        /// Método asincrono para traer una lista de objetos
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="include"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, string includeProperties = "");
        /// <summary>
        /// 
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllPagedAsync(int take, int skip, Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, string includeProperties = "");
        /// <summary>
        /// Método asincrono para actualizar un objeto
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync(TEntity entity);
        /// <summary>
        /// Método asincrono para actualizar una lista de objetos
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task UpdateRangeAsync(IEnumerable<TEntity> entities);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="orderBy"></param>
        /// <param name="selector"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Expression<Func<TEntity, TEntity>> selector = null, string includeProperties = "");
        /// <summary>
        /// Método asincrono para validar si existe un objeto
        /// </summary>
        /// <param name="whereCondition"></param>
        /// <returns></returns>
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> whereCondition = null);


    }
}
