public record Item
{
    private string itemName;
    private int itemQuantity = 0;
    private DateTime creadtedDate;

    public static int itemAmount;

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
    public int ItemAmount
    {
        get
        {
            return itemAmount;
        }
        set
        {
            if (value < 0)
            {
                throw new Exception("The Item Amount Should Not be Negative!");
            }
            else
            {
                itemAmount = value;
            }
        }
    }
    // new Item("coffee", -20, default)
    public Item(string name, int quantity, params DateTime[] createdDate)
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
        foreach (DateTime date in createdDate)
        {
            CreadtedDate = date;
        }
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
        if (MaxCapactity >= newItem.ItemQuantity + itemsList.Count())
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
            Console.WriteLine($"You have already reach the maximum capacity!");

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
        return itemsList.Count();
    }
    public void Display()
    {
        foreach (var item in itemsList)
        {
            Console.WriteLine($"{item}");
        }
        if (itemsList.Count == 0)
        {
            Console.WriteLine($"Text");
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
            Console.WriteLine($"Sorted items in ascending order: {item}");

        }
    }
    public static void Main(string[] args)
    {
        Store store = new Store(100);

        var waterBottle = new Item("Water Bottle", 10, new DateTime(2023, 1, 1));
        store.AddItem(waterBottle);
        var chocolateBar = new Item("Chocolate Bar", 15, new DateTime(2023, 2, 1));
        store.AddItem(chocolateBar);
        var notebook = new Item("Notebook", 5, new DateTime(2023, 3, 1));
        store.AddItem(notebook);
        var pen = new Item("Pen", 20, new DateTime(2023, 4, 1));
        store.AddItem(pen);
        var tissuePack = new Item("Tissue Pack", 30, new DateTime(2023, 5, 1));
        store.AddItem(tissuePack);
        var chipsBag = new Item("Chips Bag", 25, new DateTime(2023, 6, 1));
        store.AddItem(chipsBag);
        var sodaCan = new Item("Soda Can", 8, new DateTime(2023, 7, 1));
        store.AddItem(sodaCan);
        var soap = new Item("Soap", 12, new DateTime(2023, 8, 1));
        store.AddItem(soap);
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
        store.Display();


    }
}