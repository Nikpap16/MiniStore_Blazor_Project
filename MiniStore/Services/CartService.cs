using MiniStore.Models;

namespace MiniStore.Services;

public class CartService
{
    public List<CartItem> Items { get; private set; } = new();

    public event Action? OnChange;

    // Προσθήκη 
    public void Add(Product product)
    {
        var existing = Items.FirstOrDefault(i => i.Product.Id == product.Id);
        if (existing != null)
            existing.Quantity++;
        else
            Items.Add(new CartItem { Product = product, Quantity = 1 });

        NotifyStateChanged();
    }

    // μείωση προϊόντος 
    public void Decrease(Product product)
    {
        var existing = Items.FirstOrDefault(i => i.Product.Id == product.Id);
        if (existing != null)
        {
            existing.Quantity--;
            if (existing.Quantity <= 0)
                Items.Remove(existing);

            NotifyStateChanged();
        }
    }

    // Αφαίρεση  συνολικού προιοντος 
    public void RemoveAll(Product product)
    {
        var existing = Items.FirstOrDefault(i => i.Product.Id == product.Id);
        if (existing != null)
        {
            Items.Remove(existing);
            NotifyStateChanged();
        }
    }

   
    public void Clear()
    {
        Items.Clear();
        NotifyStateChanged();
    }

    // Συνολικός αριθμός προϊόντων 
    public int Count => Items.Sum(i => i.Quantity);

    private void NotifyStateChanged() => OnChange?.Invoke();
}
