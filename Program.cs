class Item {
    private string itemName;
    private int itemQuantity = 0;
    private DateTime creadtedDate = default(DateTime);

    public static int itemAmount;

    public string ItemName {
        get {
            return itemName;
            }  
        set{
            if (value == null || value == "") {
               throw new ArgumentNullException("item name should not be null or empty");
            }
            itemName = value;
        }
        }
        // var item1 = new Item("bread", 20, default)
        // item1.setQuantity(-20)
        public int ItemQuantity {
            get {
                return itemQuantity;
            }
            set{
                if (value < 0){
                    throw new Exception("The Item Quantity Should Not be Negative!");
                }else {
                    itemQuantity = value;
                }
            }
        }
        public DateTime CreadtedDate {get; set;}
        public int ItemAmount {
            get {
                return itemAmount;
            }
            set{
                if (value < 0){
                    throw new Exception("The Item Amount Should Not be Negative!");
                }else {
                    itemAmount = value;
                }
            }
        }
        // new Item("coffee", -20, default)
        public Item(string name, int quantity, params DateTime[] createdDate) {
            if(name == null || name == ""){
                throw new ArgumentNullException("item name should not be null or empty");
            }else{
                ItemName = name;
            }
            if(quantity < 0) {
                throw new Exception("The Item Quantity Should Not be Negative!");
            }else {
             ItemQuantity = quantity;   
            }
            foreach (DateTime date in createdDate){
                CreadtedDate = date;
            }
        }
    }

class Store{
    public static void AddItem() {

    }

    public static void DeletItem() {

    }

    public static void GetCurrentVolume(){
        
    }

    public static void FindItemByName(){

    }

    public static void SortByNameAsc(){

    }
    public static void Main(string[] args){   
        // items example - You do not need to follow exactly the same
        var waterBottle = new Item("Water Bottle", 10, new DateTime(2023, 1, 1));
        var chocolateBar = new Item("Chocolate Bar", 15, new DateTime(2023, 2, 1));
        var notebook = new Item("Notebook", 5, new DateTime(2023, 3, 1));
        var pen = new Item("Pen", 20, new DateTime(2023, 4, 1));
        var tissuePack = new Item("Tissue Pack", 30, new DateTime(2023, 5, 1));
        var chipsBag = new Item("Chips Bag", 25, new DateTime(2023, 6, 1));
        var sodaCan = new Item("Soda Can", 8, new DateTime(2023, 7, 1));
        var soap = new Item("Soap", 12, new DateTime(2023, 8, 1));
        var shampoo = new Item("Shampoo", 40, new DateTime(2023, 9, 1));
        var toothbrush = new Item("Toothbrush", 50, new DateTime(2023, 10, 1));
        var coffee = new Item("Coffee", 20);
        var sandwich = new Item("Sandwich", 15);
        var batteries = new Item("Batteries", 10);
        var umbrella = new Item("Umbrella", 5);
        var sunscreen = new Item("Sunscreen", 8);
    }
}