using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IProductDal
    {
        List<Product> GetAll();//Herşeyi getirecek.
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
        List<Product> GetAllByCategory(int categoryId);//Ürünleri kategorisine göre listele

    }
}
