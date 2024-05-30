namespace OnlineFoodDeliveryApplication
{
    /// <summary>
    /// Class of storing ItemDetais
    /// </summary>
    public class ItemDetails
    {
        /// <summary>
        /// Static value of ItemID
        /// </summary>
        private static int s_itemID=100;
        /// <summary>
        /// get and set the Item ID.
        /// </summary>
        /// <value></value>
        public string ItemID { get; set; }
        /// <summary>
        /// Get and set the OrderID
        /// </summary>
        /// <value></value>
        public string OrderID { get; set; }
        /// <summary>
        /// Get and set the FoodID
        /// </summary>
        /// <value></value>
        public string FoodID { get; set; }
        /// <summary>
        /// Get and set the Purcahse Count
        /// </summary>
        /// <value></value>
        public int PurchaseCount { get; set; }
        /// <summary>
        /// Get and set the Price of order.
        /// </summary>
        /// <value></value>
        public int PriceOfOrder { get; set; }
        /// <summary>
        /// Constructor class that fetch data form creating the object of the class
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="foodID"></param>
        /// <param name="purchaseCount"></param>
        /// <param name="priceOrder"></param>
        public ItemDetails(string orderID,string foodID,int purchaseCount,int priceOrder)
        {
            ItemID="ITID"+(++s_itemID);
            OrderID=orderID;
            FoodID=foodID;
            PurchaseCount=purchaseCount;
            PriceOfOrder=priceOrder;
        }

        /// <summary>
         /// Item Detail constructor that reads the data in the csv file
         /// </summary>
         /// <param name="data">data that used to read the data in csv file</param>
        public ItemDetails(string data)
        {
            string[] values = data.Split(",");
            s_itemID=int.Parse(values[0].Remove(0,4));
            ItemID=values[0];
            OrderID=values[1];
            FoodID=values[2];
            PurchaseCount=int.Parse(values[3]);
            PriceOfOrder=int.Parse(values[4]);
        }
    }
}