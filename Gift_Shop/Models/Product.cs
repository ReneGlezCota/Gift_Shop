namespace Gift_Shop.Models
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public float price { get; set; }

        public virtual Category categoryid { get; set; }
    }
}