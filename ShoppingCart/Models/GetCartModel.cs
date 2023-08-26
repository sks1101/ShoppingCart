namespace ShoppingCart.Models
{
    public class GetCartModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public string ProductName { get; set; }
        public string ProductDescription { get; set; }

        public int ProductPrice { get; set; }
    }
}
