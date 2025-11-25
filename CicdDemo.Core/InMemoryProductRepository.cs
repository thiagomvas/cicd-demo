namespace CicdDemo.Core;

public class InMemoryProductRepository : IProductRepository
{
    private readonly Dictionary<Guid, Product> _data = new();

    public void Add(Product product) => _data[product.Id] = product;

    public Product? Get(Guid id) =>
        _data.TryGetValue(id, out var result) ? result : null;

    public IEnumerable<Product> GetAll() => _data.Values;
}