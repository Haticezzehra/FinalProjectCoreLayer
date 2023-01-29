using Core.DataAccess;
using Entities.Concrete;
using Entities.DTO_s;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository <Product>
    {
        List<ProductDetailDto> GetProductDetails();

    }
}
