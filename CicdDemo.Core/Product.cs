namespace CicdDemo.Core;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    
    public Product(string name, decimal price)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Nome inválido");

        if (price <= 0)
            throw new ArgumentException("Preço deve ser maior que zero");

        Id = Guid.NewGuid();
        Name = name;
        Price = price;
    }

    public void UpdatePrice(decimal newPrice)
    {
        if (newPrice <= 0)
            throw new ArgumentException("Preço deve ser maior que zero");

        Price = newPrice;
    }
    
}