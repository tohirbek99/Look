using System.ComponentModel.DataAnnotations;

namespace Look.Models
{
    public class CartItem
    {
        public int CartId { get; set; }
        public string? CartName { get; set; }
        public int Quantity { get; set; }
        [Required, MinLength(4, ErrorMessage = "Minimum length a 4")]
        public string Description { get; set; }

        public decimal Price { get; set; }
        public decimal Total
        {
            get { return Quantity * Price; }
        }
        public string Image { get; set; }

        public CartItem()
        {

        }
        public CartItem(Product product)
        {
            CartId = product.ProductId;
            CartName=product.ProductName;
            Description = product.Description;
            Price = product.Price;
            Quantity = 1;
            Image = product.Image;

        }
    }
}
