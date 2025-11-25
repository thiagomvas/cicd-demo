namespace CicdDemo.Core;

public class ProductService
{
    private readonly IProductRepository _repo;

    public ProductService(IProductRepository repo)
    {
        _repo = repo;
    }

    public Product Create(string name, decimal price)
    {
        var product = new Product(name, price);
        _repo.Add(product);
        return product;
    }

    public Product UpdatePrice(Guid id, decimal newPrice)
    {
        var product = _repo.Get(id) ?? throw new Exception("Produto não encontrado");
        product.UpdatePrice(newPrice);
        return product;
    }

    public IEnumerable<Product> GetAll() => _repo.GetAll();
}