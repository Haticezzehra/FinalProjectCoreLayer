using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            // using kullanmayı bitirince GarbageCollector kaldırıyo bellekten.DirekNorthwindide newlwywbilirdik ama o
            //zaman belleğe çok yüklenmiş oluyoruz. Yani Northwind bellekten işi bitince atılıyo.
            //IDısposable pattern implementation pf C#
            using (NorthwindContext context = new NorthwindContext())
            {
                var addedEntity=context.Entry(entity);//Veri kaynağımla entity iilişkilendir. Referansını bul
                addedEntity.State = EntityState.Added; //Ekle
                context.SaveChanges(); // Burdaki işlemleri gerçekleştir.

            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity= context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null ?
                    context.Set<Product>().ToList()
                    :
                    context.Set<Product>().Where(filter).ToList();
            }
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
