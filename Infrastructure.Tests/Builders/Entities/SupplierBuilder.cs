using MOJ.Domain.Entities;

namespace App.Tests.Builders.Entities;

internal sealed class SupplierBuilder
{
    public Guid Reference { get; set; }
    public string Name { get; set; }
    public int Id { get; set; }

    public SupplierBuilder()
    {
        Reference = Guid.NewGuid();
        Name = "Test Supplier";
        Id = 1;
    }

    public SupplierBuilder WithReference(Guid reference)
    {
        Reference = reference;
        return this;
    }

    public SupplierBuilder WithName(string name)
    {
        Name = name;
        return this;
    }

    public SupplierBuilder WithId(int id)
    {
        Id = id;
        return this;
    }

    public Supplier Build()
    {
        return new Supplier(Name);
    }

}
