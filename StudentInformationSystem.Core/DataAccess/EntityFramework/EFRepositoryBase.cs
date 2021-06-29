using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Core.DataAccess.EntityFramework
{
    public class EFRepositoryBase<TEntity, TContext> : IRepository<TEntity>
        where TContext : DbContext, new()
        where TEntity : BaseModel
    {
        TContext db;
        DbSet<TEntity> entities;
        public EFRepositoryBase()
        {
            db = SingletonContext<TContext>.Context;
            entities = db.Set<TEntity>();
        }
        public int Add(TEntity entity)
        {
            entities.Add(entity);
            return db.SaveChanges();
        }

        public int Delete(TEntity entity)
        {
            entities.Remove(entity);
            return db.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return entities.SingleOrDefault(filter);

        }

        public ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {

            return filter == null
                    ? entities.ToList()
                    : entities.Where(filter).ToList();
        }

        public int Update(TEntity entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            return db.SaveChanges();
        }
    }
}
