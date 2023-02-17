namespace OnlineShop;



public interface IShop
{
    public Item[] GetItems();
}


public sealed class OnlineShop : IShop
{
    public Item[] GetItems()
    {
        var result = new Item[] {
            //Extend list of items.
            new Item { Id = 1, Name = "Coffee" },
            new Item { Id = 2, Name = "Tea" },
            new Item { Id = 3, Name = "Toys" },
            new Item { Id = 4, Name = "Car" },
            new Item { Id = 5, Name = "Lego" },
            new Item { Id = 6, Name = "Laptop" },
            new Item { Id = 7, Name = "Cartridge" },
            new Item { Id = 8, Name = "Pistol" },
            new Item { Id = 9, Name = "Cake" },
            new Item { Id = 10, Name = "Cookie" }
        };

        return result;
    }
}


public class Item
{
    public int Id { get; set; }

    public string Name { get; set; }
}

public class User
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
}

public class Basket
{
    private Item[] _items;

    public Basket()
    {
        _items = new Item[0];
    }


    public void Add(Item item)
    {
        if (_items.Length == 0)
        {
            _items = new Item[1];
            _items[0] = item;
            return;
        }

        var newItems = new Item[_items.Length + 1];

        for (int i = 0; i < _items.Length; i++)
        {
            newItems[i] = _items[i];
        }
        
        /// Array.Copy(_items, newItems, _items.Length);

        newItems[newItems.Length - 1] = item;
        _items = newItems;
    }

    public Item[] GetOrderItems()
    {
        return _items;
    }

    public override string ToString()
    {
        return string.Join(" ", _items.Select(x => x.Name.ToString()));
    }
}

public class Notification
{
    public void Notity(User user, Item[] items)
    {
        Console.WriteLine(user.FirstName);
        Console.WriteLine(user.LastName);

        Console.WriteLine("Bought items: ");

        for (int i = 0; i < items.Length; i++)
        {
            Console.WriteLine(items[i].Id);
        }
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        var shop = new OnlineShop();
        var items = shop.GetItems();

        // Select From array < 10 items.
        var rand = new Random().Next(0, 100);

        var first = items[0];
        var second = items[1];

        var basket = new Basket();
        
        basket.Add(first);
        basket.Add(second);

        var orderItems = basket.GetOrderItems();

        var user = new User() { FirstName = "Vlad", LastName = "VVV" };
        var notification = new Notification();

        notification.Notity(user, orderItems);
        
        Console.WriteLine(basket.ToString());
    }
}
