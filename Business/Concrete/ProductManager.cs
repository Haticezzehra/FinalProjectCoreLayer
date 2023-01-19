using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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
    }
}
