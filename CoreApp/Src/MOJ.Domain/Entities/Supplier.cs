using MOJ.SharedKernel.Contracts;
using MOJ.SharedKernel.Extensions;

namespace MOJ.Domain.Entities;

public class Supplier : Entity
{
    public string Name { get; private set; }
    public IEnumerable<Product> Products => _products.AsEnumerable();
    private readonly List<Product> _products = [];

    private Supplier() { }

    public Supplier(string name)
    {
        UpdateName(name);
    }

    public void UpdateName(string name)
    {
        Check.For.NullOrEmpty(name);
        Name = name;
    }
    public void AddProduct(Product product)
    {
        Check.For.Null(product, nameof(product));
        _products.Add(product);
    }
}