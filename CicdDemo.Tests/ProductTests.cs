using CicdDemo.Core;

namespace CicdDemo.Tests;

public class ProductTests
{
    [Test]
    public void Create_Should_CreateProductSuccessfully()
    {
        var repo = new InMemoryProductRepository();
        var service = new ProductService(repo);
        
        var name = "Paçoca";
        var price = 100m;
        
        var product = service.Create(name, price);
        
        Assert.That(product.Id, Is.Not.EqualTo(Guid.Empty));
        Assert.That(product.Name, Is.EqualTo(name));
        Assert.That(product.Price, Is.EqualTo(price));
    }
    
    [Test]
    public void Create_WhenNegativePrice_ShouldThrowException()
    {
        var repo = new InMemoryProductRepository();
        var service = new ProductService(repo);
        
        var name = "Paçoca";
        var price = -50m;
        
        var ex = Assert.Throws<ArgumentException>(() => service.Create(name, price));
        Assert.That(ex?.Message, Is.EqualTo("Preço deve ser maior que zero"));
    }
    
}