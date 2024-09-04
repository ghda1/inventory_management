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

    public Item(string name, int quantity, DateTime createdDate)
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
        CreadtedDate = createdDate;

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
        if (MaxCapactity >= newItem.ItemQuantity + GetCurrentVolume(itemsList))
        {
            var itemFound = itemsList.Any(item => item.ItemName == newItem.ItemName);
            if (!itemFound)
            {
                itemsList.Add(newItem);
                Console.WriteLine($"\"{newItem.ItemName}\" item was added successfully");

            }
            else
            {
                Console.WriteLine($"There is an item having the same name \"{newItem.ItemName}\"");

            }
        }
        else
        {
            Console.WriteLine($"The item quantity of \"{newItem.ItemName}\" you trying to add reach the maximum capacity!");

        }
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
        if (itemsList.Count != 0)
        {
            foreach (var item in itemsList)
            {
                Console.WriteLine($"item name: {item.ItemName}, item quantity: {item.ItemQuantity}, created date: {item.CreadtedDate}");
            }
        }
        else
        {
            Console.WriteLine($"The store is empty!!");
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

    public void SortByNameAsc(List<Item> itemsList)
    {
        var sortedItembyName = itemsList.OrderBy(item => item.ItemName);
        foreach (var item in sortedItembyName)
        {
            Console.WriteLine($"Sorting Items Based On Names: item name: {item.ItemName}, item quantity: {item.ItemQuantity}, created date: {item.CreadtedDate}");

        }
    }
    public void SortByDate(List<Item> itemsList)
    {
        var sortedItemByDate = itemsList.OrderBy(item => item.CreadtedDate); //sorted Asc
        foreach (var item in sortedItemByDate)
        {
            Console.WriteLine($"Sorting Items Based On Date: item name: {item.ItemName}, item quantity: {item.ItemQuantity}, created date: {item.CreadtedDate}");
        }

    }
    public void GroupByDate(List<Item> itemsList)
    {
        DateTime threeMonthAgo = DateTime.Now.AddMonths(-3);
        var oldItems = itemsList.Where(item => item.CreadtedDate < threeMonthAgo);
        Console.WriteLine($"\nOld Items: ");
        foreach (var item in oldItems)
        {
            Console.WriteLine($"item name: {item.ItemName}, item quantity: {item.ItemQuantity}, created date: {item.CreadtedDate}");

        }
        var newItems = itemsList.Where(item => item.CreadtedDate >= threeMonthAgo);
        Console.WriteLine($"\n \nNew Arrival Items:");
        foreach (var item in newItems)
        {
            Console.WriteLine($"item name: {item.ItemName}, item quantity: {item.ItemQuantity}, created date: {item.CreadtedDate}");

        }
    }
    public static void Main(string[] args)
    {
        Store store = new Store(400);

        var coffee = new Item("Coffee", 20, DateTime.Now);
        store.AddItem(coffee);
        var sandwich = new Item("Sandwich", 15, DateTime.Now);
        store.AddItem(sandwich);
        var batteries = new Item("Batteries", 10, DateTime.Now);
        store.AddItem(batteries);
        var umbrella = new Item("Umbrella", 5, DateTime.Now);
        store.AddItem(umbrella);
        var waterBottle = new Item("Water Bottle", 10, new DateTime(2023, 1, 1));
        store.AddItem(waterBottle);
        var chocolateBar = new Item("Chocolate Bar", 15, new DateTime(2023, 2, 1));
        store.AddItem(chocolateBar);
        var notebook = new Item("Notebook", 5, new DateTime(2023, 3, 1));
        store.AddItem(notebook);
        var pen = new Item("Pen", 20, new DateTime(2023, 4, 1));
        store.AddItem(pen);
        store.Display(store.itemsList);
        store.DeletItem("Pen");
        store.FindItemByName("Umbrella");
        store.FindItemByName("Pen");
       Console.WriteLine($"Total : {store.GetCurrentVolume(store.itemsList)}");
       store.Display(store.itemsList);
       store.SortByNameAsc(store.itemsList);
       store.SortByDate(store.itemsList);
       store.GroupByDate(store.itemsList);
    }
}