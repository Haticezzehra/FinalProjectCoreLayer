using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{ //Bir entity tipi ve bir context tipi yazmamızı istiyor
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
   where TEntity : class, Entities.TEntity, new()
where TContext : DbContext, new()

    {
        public void Add(TEntity entity)
        {
            // using kullanmayı bitirince GarbageCollector kaldırıyo bellekten.DirekNorthwindide newlwywbilirdik ama o
            //zaman belleğe çok yüklenmiş oluyoruz. Yani Northwind bellekten işi bitince atılıyo.
            //IDısposable pattern implementation pf C#
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);//Veri kaynağımla entity iilişkilendir. Referansını bul
                addedEntity.State = EntityState.Added; //Ekle
                context.SaveChanges(); // Burdaki işlemleri gerçekleştir.

            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ?
                    context.Set<TEntity>().ToList()
                    :
                    context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public List<TEntity> GetAllByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
