using Prueba.DataAccess.Context;
using Prueba.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Prueba.DataAccess.Class
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DbSet<TEntity> dbSet;
        private readonly PruebaContext dbContext;

        public Repository(PruebaContext pruebaContext)
        {
            this.dbContext = pruebaContext;
            this.dbSet = dbContext.Set<TEntity>();
        }

        /// <summary>
        /// Add new entity 
        /// </summary>
        /// <param name="entity">Entity to add </param>
        public virtual void Create(TEntity entity)
        {
            dbSet.Add(entity);
        }

        /// <summary>
        /// Add new List of Entity
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Create(IEnumerable<TEntity> entity)
        {
            foreach (var item in entity)
            {
                dbSet.Add(item);
            }

        }

        /// <summary>
        /// Find Entity by paremter expression 
        /// </summary>
        /// <param name="predicate">paremter expression to filter entities</param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, string[] IncludeProperties = null)
        {

            IQueryable<TEntity> Query = dbSet;
            if (IncludeProperties != null)
            {
                foreach (var inlcudeProperty in IncludeProperties)
                {
                    Query = Query.Include(inlcudeProperty);
                }
            }
            return Query.AsNoTracking().Where(predicate);
            //return Query.Where(predicate).ToList();

        }

        /// <summary>
        /// Find All entities and can include relationsship
        /// </summary>
        /// <param name="IncludeProperties">relationsship properties</param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> FindAll(string[] IncludeProperties = null)
        {
            IQueryable<TEntity> Query = dbSet;
            if (IncludeProperties != null)
            {
                foreach (var inlcudeProperty in IncludeProperties)
                {
                    Query = Query.Include(inlcudeProperty);
                }
            }
            return Query.AsNoTracking();
            //return Query.ToList();
        }

        /// <summary>
        /// Find Entity by Id
        /// </summary>
        /// <param name="Id">Entity Id</param>
        /// <returns>Entity Found</returns>
        public virtual TEntity FindById(int Id)
        {
            return dbSet.Find(Id);
        }

        /// <summary>
        /// Update Entity
        /// </summary>
        /// <param name="entity">Entity to update</param>
        public virtual void Update(TEntity entity)
        {
            DbEntityEntry DbEntityEntry = dbContext.Entry(entity);
            var key = this.GetPrimaryKey(DbEntityEntry);
            if (DbEntityEntry.State == EntityState.Detached)
            {
                TEntity currentEntity = this.FindById(key);
                if (currentEntity != null)
                {
                    DbEntityEntry AttachedEntry = dbContext.Entry(currentEntity);
                    AttachedEntry.CurrentValues.SetValues(entity);

                }
                else
                {
                    dbSet.Attach(entity);
                    DbEntityEntry.State = EntityState.Modified;
                }
            }
        }

        /// <summary>
        /// Get Key attribute of entity
        /// </summary>
        /// <param name="entry">entity</param>
        /// <returns>Int key Value</returns>
        private int GetPrimaryKey(DbEntityEntry entry)
        {
            var myObject = entry.Entity;
            var property =
                myObject.GetType()
                    .GetProperties()
                    .FirstOrDefault(prop => Attribute.IsDefined(prop, typeof(KeyAttribute)));
            return (int)property.GetValue(myObject, null);
        }

        /// <summary>
        /// Delete a entity
        /// </summary>
        /// <param name="entity">Entity to Delete</param>
        public virtual void Delete(TEntity entity)
        {
            DbEntityEntry dbEntityEntry = dbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                dbSet.Attach(entity);
                dbSet.Remove(entity);
            }
        }

        /// <summary>
        /// Delete a entity by Id
        /// </summary>
        /// <param name="entity">Id of Entity to Delete</param>
        public virtual void Delete(int Id)
        {
            TEntity entity = FindById(Id);
            if (entity == null) return;
            Delete(entity);
        }
    }
}
