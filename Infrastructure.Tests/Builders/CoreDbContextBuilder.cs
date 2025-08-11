using MediatR;
using Microsoft.EntityFrameworkCore;
using MOJ.Infrastructure.Persistence;
using MOJ.SharedKernel.Contracts;
using Moq;

namespace App.Tests.Builders;

internal sealed class CoreDbContextBuilder
{
    public string DbName { get; private set; }

    public CoreDbContextBuilder()
    {
        DbName = Guid.NewGuid().ToString();
    }
    public CoreDbContextBuilder WithDbName(string dbName)
    {
        DbName = dbName;
        return this;
    }

    public CoreDbContext Build(bool useSqlite = false)
    {
     
        var dbOptions = useSqlite
            ? new DbContextOptionsBuilder<CoreDbContext>().UseSqlite($"Data Source={DbName}.db").Options
            : new DbContextOptionsBuilder<CoreDbContext>()
                        .UseInMemoryDatabase(databaseName: DbName)
                        .Options;

        var mediatorMock = new Mock<IMediator>();

        var dbContext = new CoreDbContext(dbOptions, mediatorMock.Object);

        dbContext.Database.EnsureCreated();

        return dbContext;
    }
}
