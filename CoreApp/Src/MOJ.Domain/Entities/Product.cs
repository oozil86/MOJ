using MOJ.Domain.ValueObjects;
using MOJ.SharedKernel.Contracts;
using MOJ.SharedKernel.Extensions;

namespace MOJ.Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; private set; }
        public int Quantity { get; private set; }
        public int UnitsInStock { get; private set; }
        public int UnitsOnOrder { get; private set; }
        public int SupplierId { get; private set; }
        public ProductBasicInfo ProductBasicInfo { get; private set; }
        public Supplier Supplier { get; private set; }

        private Product() { }
        public Product(string name, int quantity, int unitsInStock, int unitsOnOrder, ProductBasicInfo productBasicInfo)
        {
            UpdateName(name);
            UpdateUnitsInStock(unitsInStock);
            UpdateUnitsOnOrder(unitsOnOrder);
            UpdateBasicInfo(productBasicInfo);
            UpdateQuantity(quantity);
        }
        public void UpdateName(string name)
        {
            Check.For.NullOrEmpty(name, nameof(name));
            Name = name;
        }
        public void UpdateQuantity(int quantity)
        {
            Check.For.IntLessThanZero(quantity);
            Quantity = quantity;
        }
        public void UpdateUnitsInStock(int unitsInStock)
        {
            Check.For.IntLessThanZero(unitsInStock);
            UnitsInStock = unitsInStock;
        }
        public void UpdateUnitsOnOrder(int unitsOnOrder)
        {
            Check.For.IntLessThanZero(unitsOnOrder);
            UnitsOnOrder = unitsOnOrder;
        }
        public void UpdateBasicInfo(ProductBasicInfo productBasicInfo)
        {
            Check.For.Null(productBasicInfo);

            if (!productBasicInfo.Equals(ProductBasicInfo))
            {
                ProductBasicInfo = productBasicInfo;
            }
        }
    }
}