using MOJ.Domain.Enums;
using MOJ.SharedKernel.Contracts;
using MOJ.SharedKernel.Extensions;

namespace MOJ.Domain.ValueObjects;

public class ProductBasicInfo : ValueObject
{
    public decimal UnitPrice { get; private set; }
    public int ReorderLevel { get; private set; }
    public ProductUnit ProductUnit { get; private set; }

    private ProductBasicInfo() { }
    public ProductBasicInfo(decimal unitPrice, int reorderLevel, ProductUnit productUnit)
    {
        UpdateUnitPrice(unitPrice);
        UpdateReorderLevel(reorderLevel);
        UpdateProductUnit(productUnit);
    }
    public void UpdateUnitPrice(decimal unitPrice)
    {
        Check.For.DecimalLessThanZero(unitPrice);
        UnitPrice = unitPrice;
    }
    public void UpdateReorderLevel(int reorderLevel)
    {
        Check.For.DecimalLessThanZero(reorderLevel);
        ReorderLevel = reorderLevel;
    }
    public void UpdateProductUnit(ProductUnit productUnit)
    {
        Check.For.Null(productUnit);
        ProductUnit = productUnit;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return UnitPrice;
        yield return ReorderLevel;
        yield return ProductUnit;
    }
}
