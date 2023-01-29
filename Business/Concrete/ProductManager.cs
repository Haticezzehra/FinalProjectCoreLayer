using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal productDal;//DependencyInjection

        public ProductManager(IProductDal productDal)
        {
            this.productDal = productDal;
        }

        public List<Product> GetAll()
        {
           return productDal.GetAll();   
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return productDal.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return productDal.GetAll(p=>p.UnitPrice>=min &&p.UnitPrice<=max);   
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return productDal.GetProductDetails();
        }
    }
}
