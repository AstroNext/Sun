using Framework.Application.Domain;
using Sun.Domain.CartItemAgg;
using Sun.Domain.ProductBrandAgg;
using Sun.Domain.ProductCategoryAgg;
using Sun.Domain.UnitAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.Domain.ProductAgg
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public bool IsRemoved { get; set; }
        public long CategoryId { get; set; }
        public Category Category { get; set; }
        public long BrandId { get; set; }
        public Brand Brand { get; set; }
        public long UnitId { get; set; }
        public Unit Unit { get; set; }
        public long StockId { get; set; }
        public double StockCount { get; set; }
        public List<CartItem> Items { get; set; }

        public Product(){}
        public Product(string name, double unitPrice, long ctegoryId, long brandId, long unitId)
        {
            Name = name;
            UnitPrice = unitPrice;
            CategoryId = ctegoryId;
            BrandId = brandId;
            UnitId = unitId;
            StockCount = 0;
        }
        public void Edit(string name, double unitPrice, long ctegoryId, long brandId, long unitId)
        {
            Name = name;
            UnitPrice = unitPrice;
            CategoryId = ctegoryId;
            BrandId = brandId;
            UnitId = unitId;
        }
        public void Remove()
        {
            IsRemoved = true;
        }
        public void Restore()
        {
            IsRemoved = false;
        }
        public void AddStock(double count)
        {
            StockCount += count;
        }
        public void SellStock(double count)
        {
            StockCount -= count;
        }
    }
}
