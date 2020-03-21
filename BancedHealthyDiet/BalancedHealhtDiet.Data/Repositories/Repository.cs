using BalancedHealhtDiet.Data.Configuration;
using BancedHealthyDiet.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace BancedHealthyDiet.Data.Repositories
{
    public class Repository<TEntity> : IGenericRepository<TEntity> where TEntity : class,IEntity,new()
    {
        private string errorMessage = string.Empty;
        private bool isDisposed;
        private  BalanceDietAppContext appContext;
        IDbSet<TEntity> dbSet;

        protected virtual IDbSet<TEntity> Entities
        {
            get { return dbSet ?? (dbSet = appContext.Set<TEntity>()); }

        }

        public Repository(BalanceDietAppContext appContext)
        {
            this.appContext = appContext;
            isDisposed = false;
           // dbSet = appContext.Set<TEntity>();
        }
        public virtual TEntity Get(Guid id)
        {
            return GetAll().FirstOrDefault(entity => entity.Id == id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return Entities.ToList();
        }

        public virtual void Insert(TEntity entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
                var entityInDatabase =  Entities.Local.Any(e => e == entity);
                if (entityInDatabase)
                {
                    Update(entity);
                }
                else
                {
                    Entities.Add(entity);
                }

            }
            catch(DbEntityValidationException dbExeption)
            {
                foreach (var vallidationExeption in dbExeption.EntityValidationErrors)
                    foreach (var validationError in vallidationExeption.ValidationErrors)
                        errorMessage += string.Format("Property: {0}, Error: {1}", validationError.PropertyName, 
                            validationError.ErrorMessage) + Environment.NewLine;
                throw new Exception(errorMessage, dbExeption);

            }
        }

        public virtual void Delete(TEntity entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
                if (appContext == null || isDisposed)
                    appContext = new BalanceDietAppContext();
                Entities.AsNoTracking();
                appContext.Entry(entity).State = EntityState.Deleted;
                //Context.SaveChanges(); commented out call to SaveChanges as Context save changes will be called with Unit of work
            }
            catch (DbEntityValidationException dbExeption)
            {
                foreach (var vallidationExeption in dbExeption.EntityValidationErrors)
                    foreach (var validationError in vallidationExeption.ValidationErrors)
                        errorMessage += string.Format("Property: {0}, Error: {1}", validationError.PropertyName,
                            validationError.ErrorMessage) + Environment.NewLine;
                throw new Exception(errorMessage, dbExeption);
            }
        }

        public virtual void Update(TEntity entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
                if (appContext == null || isDisposed)
                    appContext =  new BalanceDietAppContext();
                appContext.Entry(entity).State = EntityState.Modified;
                //Context.SaveChanges(); commented out call to SaveChanges as Context save changes will be called with Unit of work
            }
            catch (DbEntityValidationException dbExeption)
            {
                foreach (var vallidationExeption in dbExeption.EntityValidationErrors)
                    foreach (var validationError in vallidationExeption.ValidationErrors)
                        errorMessage += string.Format("Property: {0}, Error: {1}", validationError.PropertyName,
                            validationError.ErrorMessage) + Environment.NewLine;
                throw new Exception(errorMessage, dbExeption);
            }
        }
        public void Dispose()
        {
            if (appContext != null)
                appContext.Dispose();
            isDisposed = true;
        }
    }
}
