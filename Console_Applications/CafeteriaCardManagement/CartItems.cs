using System.Data.Common;
namespace CafeteriaCardManagement
{
    public class CartItems
    {
        public static int s_itemID=100;
        public string ItemID { get; set; }
        public string OrderID { get; set; }
        public string FoodID { get; set; }
        public int OrderPrice { get; set; }
        public int OrderQuantity { get; set; }

        public CartItems(string orderID,string foodID,int orderPrice,int orderQuantity)
        {
                ItemID="ITID"+(++s_itemID);
                OrderID=orderID;
                FoodID=foodID;
                OrderPrice=orderPrice;
                OrderQuantity=orderQuantity;
            }

        public CartItems(string data)
        {
            string[] values = data.Split(",");
            s_itemID=int.Parse(values[0].Remove(0,4));
            ItemID=values[0];
            OrderID=values[1];
            FoodID=values[2];
            OrderPrice=int.Parse(values[3]);
            OrderQuantity=int.Parse(values[4]);
        }

        
    }
}