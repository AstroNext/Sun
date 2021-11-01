namespace Sun.Application.Contaracts.Product
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Unit { get; set; }
        public bool IsRemoved { get; set; }
        public string CreationDate { get; set; }
    }
}
