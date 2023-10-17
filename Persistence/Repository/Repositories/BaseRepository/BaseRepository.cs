using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Persistence.Repository.IRepositories.Generic;
using Persistence.Repository.IRepositories.IBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository.Repositories.BaseRepository
{
    public class BaseRepository<TId, TEntity> : IBaseRepository<TId, TEntity>
        where TId : struct
        where TEntity : class
    {
        protected readonly IUnitOfWork _unitOfWork;

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(TEntity entity)
        {
            ValidateEntity(entity);
            await _unitOfWork.GetSet<TId, TEntity>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            ValidateRangeEntities(entities);
            await _unitOfWork.GetSet<TId,TEntity>().AddRangeAsync(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? filter = null)
        {
            var item = _unitOfWork.GetSet<TId, TEntity>().AsNoTracking();
            return filter == null ? await item.AnyAsync() : await item.AnyAsync(filter);
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>>? filter = null)
            => await BuildQuery(filter).CountAsync();
        
        
        public async Task<TEntity> FindByIdAsync(TId id)
            => await _unitOfWork.GetSet<TId, TEntity>().FindAsync(id) == null ? null : await _unitOfWork.GetSet<TId, TEntity>().FindAsync(id);


        public async Task<bool> DeleteAsync(TEntity entity)
        {
            ValidateEntity(entity);

            bool deleted = false;

            var removeEntity = _unitOfWork.GetSet<TId, TEntity>().Remove(entity);
            
            if (removeEntity != null)
            {
                deleted = true;
            }

            await _unitOfWork.CommitAsync();

            return deleted;
        }
        public async Task<bool> DeleteAsync(TId Id)
        {
            
            var item = await FindByIdAsync(Id);
            ValidateEntity(item);

            return await DeleteAsync(item);

        }

#pragma warning disable // El método asincrónico carece de operadores "await" y se ejecutará de forma sincrónica
        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>>? whereCondition = null)
        {
            var count = _unitOfWork.GetSet<TId, TEntity>().Where(whereCondition).Count();
            return count > 0;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, string includeProperties = "")
            => await BuildQuery(filter, orderBy, include, includeProperties).ToListAsync();
        

        public async Task<IEnumerable<TEntity>> GetAllPagedAsync(int take, int skip, Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, string includeProperties = "")
            => await BuildQuery(filter, orderBy, null, includeProperties).Skip(skip).Take(take).ToListAsync();
        

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Expression<Func<TEntity, TEntity>> selector = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = _unitOfWork.GetSet<TId, TEntity>().AsNoTracking();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(property =>
            {
                query = query.Include(property);
            });

            if (orderBy != null)
            {
                if (selector != null)
                {
                    return await orderBy(query).Select(selector).FirstOrDefaultAsync();
                }

                return await orderBy(query).FirstOrDefaultAsync();
            }

            if (selector != null)
            {
                return await query.Select(selector).FirstOrDefaultAsync();
            }

            return await query.AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            ValidateEntity(entity);
            _unitOfWork.GetSet<TId, TEntity>().Update(entity);
        }

        public async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            ValidateRangeEntities(entities);

            foreach (var entity in entities)
            {
                _unitOfWork.GetSet<TId, TEntity>().Update(entity);
                await _unitOfWork.GetContext().SaveChangesAsync();
            }
        }

        private IQueryable<TEntity> BuildQuery(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            string includeProperties = "")
        {
            var query = _unitOfWork.GetSet<TId, TEntity>().AsNoTracking();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (include != null)
            {
                query = include(query);
            }

            includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(property =>
            {
                query = query.Include(property);
            });

            if (orderBy != null)
            {
                return orderBy(query);
            }

            return query;
        }
        private static void ValidateEntity(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "El objeto entidad no puede ser nulo");
            }
        }

        private static void ValidateRangeEntities(IEnumerable<TEntity> entities)
        {
            if (!entities?.Any() ?? true)
            {
                throw new ArgumentNullException(nameof(entities), "no se envió una lista de entidades a insertar");
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
        }
    }
}
