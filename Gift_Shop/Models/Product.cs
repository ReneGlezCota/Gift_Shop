namespace Gift_Shop.Models
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string imagepath { get; set; }
        public float price { get; set; }

        public int categoryID { get; set; }
        public virtual Category category { get; set; }
    }
}