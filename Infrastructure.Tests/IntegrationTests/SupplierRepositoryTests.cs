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
}
