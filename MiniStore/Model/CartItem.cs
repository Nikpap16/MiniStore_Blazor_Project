using MiniStore.Models;



public class CartItem
{
    public Product Product { get; set; } = default!;
    public int Quantity { get; set; }
}
