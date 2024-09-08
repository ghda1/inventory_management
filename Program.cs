class Item
{
    private string itemName;
    private int itemQuantity = 0;
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
                throw new ArgumentNullException("Item name should not be null or empty!");
            }
            itemName = value;
        }
    }
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
                throw new Exception("The item quantity should not be negative!");
            }
            else
            {
                itemQuantity = value;
            }
        }
    }
    public DateTime CreadtedDate { get; set; }

    public Item(string name, int quantity, DateTime? createdDate = null)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException("Item name should not be null or empty");
        }
        else
        {
            ItemName = name;
        }
        if (quantity < 0)
        {
            throw new Exception("The item quantity should not be negative!");
        }
        else
        {
            ItemQuantity = quantity;
        }
        CreadtedDate = createdDate ?? DateTime.Now;

    }
}

class Store
{
    public int MaxCapactity;
    private List<Item> itemsList = new List<Item>();
    public Store(int maxCapactity)
    {
        MaxCapactity = maxCapactity;
    }
    public void AddItem(Item newItem)
    {
        if (MaxCapactity < newItem.ItemQuantity + GetCurrentVolume(itemsList))
        {
            Console.WriteLine($"The item quantity of \"{newItem.ItemName}\" you trying to add reach the maximum capacity!");
            return;
        }
        if (itemsList.Any(item => item.ItemName == newItem.ItemName))
        {
            Console.WriteLine($"There is an item having the same name \"{newItem.ItemName}\"");
            return;
        }

        itemsList.Add(newItem);
        Console.WriteLine($"\"{newItem.ItemName}\" item was added successfully");
    }

    public void DeletItem(string name)
    {
        var itemBasedOnName = itemsList.FirstOrDefault(item => item.ItemName == name);
        if (itemBasedOnName != null)
        {
            itemsList.Remove(itemBasedOnName);
            Console.WriteLine($"\"{name}\" item was removed successfully");
        }
        else
        {
            Console.WriteLine($"There is no item called \"{name}\"!");
        }
    }

    public int GetCurrentVolume(List<Item> itemsList)
    {
        return itemsList.Sum(item => item.ItemQuantity);

    }
    public void Display(List<Item> itemsList)
    {
        if (itemsList.Count == 0)
        {
            Console.WriteLine($"The store is empty!!");
            return;
        }

        foreach (var item in itemsList)
        {
            Console.WriteLine($"item name: {item.ItemName}, item quantity: {item.ItemQuantity}, created date: {item.CreadtedDate}");
        }
    }

    public void FindItemByName(string name)
    {
        var itemBasedOnName = itemsList.FirstOrDefault(item => item.ItemName == name);
        if (itemBasedOnName != null)
        {
            Console.WriteLine($"Found: {itemBasedOnName.ItemName}, item quantity: {itemBasedOnName.ItemQuantity}, created date: {itemBasedOnName.CreadtedDate}");
        }
        else
        {
            Console.WriteLine($"There is no item called \"{name}\"!");

        }
    }

    public void SortByName(List<Item> itemsList)
    {
        var sortedItembyName = itemsList.OrderBy(item => item.ItemName).ToList();
        Console.WriteLine("\nSorting items based on name: ");
        Display(sortedItembyName);
    }
    public void SortByDate(List<Item> itemsList)
    {
        var sortedItemByDate = itemsList.OrderBy(item => item.CreadtedDate).ToList(); //sorted Asc
        Console.WriteLine("\nSorting items based on date:");
        Display(sortedItemByDate);

    }
    public IEnumerable<IGrouping<string, Item>> GroupByDate()
    {
        var now = DateTime.Now;
        var threeMonthAgo = now.AddMonths(-3);

        var groupedByDate = itemsList.GroupBy(item => item.CreadtedDate >= threeMonthAgo
        ? "New Arrival:"
        : "Old:");

        return groupedByDate;
    }
    public static void Main(string[] args)
    {
        Store store = new Store(400);

        var coffee = new Item("Coffee", 20);
        store.AddItem(coffee);
        var sandwich = new Item("Sandwich", 15);
        store.AddItem(sandwich);
        var batteries = new Item("Batteries", 10);
        store.AddItem(batteries);
        var umbrella = new Item("Umbrella", 5);
        store.AddItem(umbrella);
        var waterBottle = new Item("Water Bottle", 10, new DateTime(2023, 1, 1));
        store.AddItem(waterBottle);
        var chocolateBar = new Item("Chocolate Bar", 15, new DateTime(2023, 2, 1));
        store.AddItem(chocolateBar);
        var notebook = new Item("Notebook", 5, new DateTime(2023, 3, 1));
        store.AddItem(notebook);
        var pen = new Item("Pen", 20, new DateTime(2023, 4, 1));
        store.AddItem(pen);
        Console.WriteLine($"");

        store.Display(store.itemsList);
        store.DeletItem("Pen");
        store.FindItemByName("Umbrella");
        store.FindItemByName("Pen");
        Console.WriteLine($"Total : {store.GetCurrentVolume(store.itemsList)}");
        store.Display(store.itemsList);
        store.SortByName(store.itemsList);
        store.SortByDate(store.itemsList);

        var groupedByDate = store.GroupByDate();
        foreach (var group in groupedByDate)
        {
            Console.WriteLine($"\n{group.Key}");
            foreach (var item in group)
            {
                Console.WriteLine($"item name: {item.ItemName}, item quantity: {item.ItemQuantity}, created date: {item.CreadtedDate}");

            }
        }
    }
}
