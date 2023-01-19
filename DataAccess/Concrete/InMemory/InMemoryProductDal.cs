using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> products;
        public InMemoryProductDal()
        {
            products = new List<Product>
            {
                new Product{
                    ProductId = 1,CategoryId= 1 ,ProductName="Bardak",UnitPrice =15,UnitsInStock=15
                },
                  new Product{
                    ProductId = 2,CategoryId= 1 ,ProductName="Kamera",UnitPrice =500,UnitsInStock=1
                },
                    new Product{
                    ProductId = 3,CategoryId= 1 ,ProductName="Telefon",UnitPrice =1500,UnitsInStock=5
                },
                      new Product{
                    ProductId = 4,CategoryId= 1 ,ProductName="Klavye",UnitPrice =150,UnitsInStock=56
                },
                        new Product{
                    ProductId = 5,CategoryId= 1 ,ProductName="Fare",UnitPrice =95,UnitsInStock=11
                },

            };

        }
        public void Add(Product product)
        {
            products.Add(product);
        }
        //LINQ= Language Integrated Query//Dile gömülü sorgulama
        public void Delete(Product product)
        {
            //LINQ Olmadan Kullanım.
            /* foreach (Product p in products)
             {
                 if (p.ProductId == product.ProductId)
                 {
                     products.Remove(p);
                 }
             }*/
            //LINQ Kullanımı
            Product productToDelete = null;
            productToDelete = products.SingleOrDefault();
            products.Remove(productToDelete);

        }

        public List<Product> GetAll()
        {

            return products;
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
