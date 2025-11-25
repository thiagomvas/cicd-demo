namespace CicdDemo.Core;
public interface IProductRepository
{
    void Add(Product product);
    Product? Get(Guid id);
    IEnumerable<Product> GetAll();
}
