namespace CafeteriaCardManagement
{
    public class FoodDetails
    {
        public static int s_foodID=100;
        public string FoodID { get; set; }
        public string FoodName { get; set; }
        public int FoodPrice { get; set; }
        public int FoodQuantity { get; set; }

        public FoodDetails(string foodName,int foodPrice,int foodQuantity)
        {
            FoodID="FID"+(++s_foodID);
            FoodName=foodName;
            FoodPrice=foodPrice;
            FoodQuantity=foodQuantity;
        }

        public FoodDetails(string data)
        {
            string[] values=data.Split(",");
            s_foodID=int.Parse(values[0].Remove(0,3));
            FoodID=values[0];
            FoodName=values[1];
            FoodPrice=int.Parse(values[2]);
            FoodQuantity=int.Parse(values[3]);
        }

    }
}