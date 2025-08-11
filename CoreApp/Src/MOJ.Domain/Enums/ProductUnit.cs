using MOJ.SharedKernel.Contracts;
using System.Runtime.CompilerServices;

namespace MOJ.Domain.Enums;

public class ProductUnit : BaseEnum<ProductUnit>
{
    public static readonly ProductUnit Kilo = new(1);
    public static readonly ProductUnit Box = new(2);
    public static readonly ProductUnit Can = new(3);
    public static readonly ProductUnit Liter = new(4);
    public static readonly ProductUnit Bottle = new(5);

    private ProductUnit(int value, [CallerMemberName] string name = "")
        : base(value, name)
    {
    }
}
