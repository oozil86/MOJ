using App.Tests.Builders;
using App.Tests.Builders.Entities;
using App.Tests.Builders.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace App.Tests.IntegrationTests;

public sealed class SupplierRepositoryTests
{

    [Fact]
    public async Task AddAsync_WhenModelIsValid_ShouldSave()
    {
        var context = new CoreDbContextBuilder()
            .Build();
     
        var supplier = new SupplierBuilder()
            .Build();

        var supplierRepository = new SupplierRepositoryBuilder()
            .WithDbContext(context)
            .Build();

        await supplierRepository
            .AddAsync(supplier, CancellationToken.None);

        await context.SaveChangesAsync();

        var count = await context.Suppliers.CountAsync();

        count.Should().Be(1);
    }

    [Fact]
    public async Task GetByReference_WhenModelIsValid_ReturnsModel()
    {
        var reference = Guid.NewGuid();
        var context = new CoreDbContextBuilder()
            .Build();

        var supplier = new SupplierBuilder()
            .WithReference(reference)
            .Build();

        var supplierRepository = new SupplierRepositoryBuilder()
            .WithDbContext(context)
            .Build();

        await supplierRepository
            .AddAsync(supplier, CancellationToken.None);

        await context.SaveChangesAsync();

        var result = await supplierRepository.GetByReferenceAsync(reference);

        result.Should().NotBeNull();
        result.Id.Should().Be(supplier.Id);
        result.Name.Should().Be(supplier.Name);
        result.Reference.Should().Be(supplier.Reference);
    }

    [Fact]
    public async Task GetById_WhenModelIsValid_ReturnsModel()
    {
        var context = new CoreDbContextBuilder()
            .Build();

        var supplier = new SupplierBuilder()
            .WithId(1)
            .Build();

        var supplierRepository = new SupplierRepositoryBuilder()
            .WithDbContext(context)
            .Build();

        await supplierRepository
            .AddAsync(supplier, CancellationToken.None);

        await context.SaveChangesAsync();

        var result = await supplierRepository.GetByIdAsync(1);

        result.Should().NotBeNull();
        result.Id.Should().Be(supplier.Id);
        result.Name.Should().Be(supplier.Name);
        result.Reference.Should().Be(supplier.Reference);
    }

    [Fact]
    public async Task Delete_WhenModelIsValid_ReturnsModel()
    {
        var context = new CoreDbContextBuilder()
            .Build();

        var supplier = new SupplierBuilder()
            .WithId(1)
            .Build();

        var supplierRepository = new SupplierRepositoryBuilder()
            .WithDbContext(context)
            .Build();

        await supplierRepository
            .AddAsync(supplier, CancellationToken.None);
   
        await context.SaveChangesAsync();

        var resultBeforeDelte = await supplierRepository.GetByIdAsync(1);
        resultBeforeDelte.Should().NotBeNull();
        resultBeforeDelte.Id.Should().Be(supplier.Id);

        supplierRepository.Delete(supplier);
        await context.SaveChangesAsync();

        var result = await supplierRepository.GetByIdAsync(1);

        result.Should().BeNull();  
    }
}
