class Item
{
    private string itemName;
    private int itemQuantity = 0;
    private string creadtedDate;

    public string ItemName
    {
        get
        {
            return itemName;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("item name should not be null or empty");
            }
            itemName = value;
        }
    }
    // var item1 = new Item("bread", 20, default)
    // item1.setQuantity(-20)
    public int ItemQuantity
    {
        get
        {
            return itemQuantity;
        }
        set
        {
            if (value < 0)
            {
                throw new Exception("The Item Quantity Should Not be Negative!");
            }
            else
            {
                itemQuantity = value;
            }
        }
    }
    public DateTime CreadtedDate { get; set; }

    // new Item("coffee", -20, default)
    public Item(string name, int quantity)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException("item name should not be null or empty");
        }
        else
        {
            ItemName = name;
        }
        if (quantity < 0)
        {
            throw new Exception("The Item Quantity Should Not be Negative!");
        }
        else
        {
            ItemQuantity = quantity;
        }
        creadtedDate = DateTime.Now.ToShortDateString();

    }
}

class Store
{
    public int MaxCapactity;
    List<Item> itemsList = new List<Item>();
    public Store(int maxCapactity)
    {
        MaxCapactity = maxCapactity;
    }
    public void AddItem(Item newItem)
    {
        if (MaxCapactity >= newItem.ItemQuantity + GetCurrentVolume())
        {
            var itemFound = itemsList.FirstOrDefault(item => item.ItemName == newItem.ItemName);
            if (itemFound == null)
            {
                itemsList.Add(newItem);
                Console.WriteLine($"{newItem.ItemName} Was added successfully");

            }
            else
            {
                Console.WriteLine($"There is an item having the same name!");

            }
        }
        else
        {
            Console.WriteLine($"The item quantity you trying to add reach the maximum capacity!");

        }
    }
    public void DeletItem(string name)
    {
        var itemBasedOnName = itemsList.FirstOrDefault(item => item.ItemName == name);
        if (itemBasedOnName != null)
        {
            itemsList.Remove(itemBasedOnName);
            Console.WriteLine($"{name} Was removed successfully");
        }
        else
        {
            Console.WriteLine($"There is no item called {name}!");
        }
    }

    public int GetCurrentVolume()
    {
        int volume = 0;
        foreach (var item in itemsList)
        {
            volume += item.ItemQuantity;
        }
        return volume;
    }
    public void Display(List<Item> itemsList)
    {
        foreach (var item in itemsList)
        {
            Console.WriteLine($"item name: {item.ItemName}, item quantity: {item.ItemQuantity}, created date: {item.CreadtedDate}");
        }
        if (itemsList.Count == 0)
        {
            Console.WriteLine($"The store is empty!!");
        }
    }

    public void FindItemByName(string name)
    {
        var itemBasedOnName = itemsList.FirstOrDefault(item => item.ItemName == name);
        if (itemBasedOnName != null)
        {
            Console.WriteLine($"Found: {itemBasedOnName}");
        }
        else
        {
            Console.WriteLine($"There is no item called {name}!");

        }
    }

    public void SortByNameAsc()
    {
        var sortedItem = itemsList.OrderBy(item => item.ItemName);
        foreach (var item in sortedItem)
        {
            Console.WriteLine($"Sorting Items: item name: {item.ItemName}, item quantity: {item.ItemQuantity}, created date: {item.CreadtedDate}");

        }
    }
    public void GroupByDate()
    {
    }
    public static void Main(string[] args)
    {
        Store store = new Store(100);

        var coffee = new Item("Coffee", 20);
        store.AddItem(coffee);
        var sandwich = new Item("Sandwich", 15);
        store.AddItem(sandwich);
        var batteries = new Item("Batteries", 10);
        store.AddItem(batteries);
        var umbrella = new Item("Umbrella", 5);
        store.AddItem(umbrella);
        var sunscreen = new Item("Sunscreen", 8);
        store.AddItem(sunscreen);
        store.Display(store.itemsList);
        Console.WriteLine($"Total item: {store.GetCurrentVolume()}");
        store.DeletItem("Sunscreen");
        Console.WriteLine($"Total item: {store.GetCurrentVolume()}");
        store.FindItemByName("water");
        store.SortByNameAsc();



    }
}