using System.Runtime.Intrinsics.X86;
namespace OnlineFoodDeliveryApplication
{
    public class FoodDetails
    {
        /// <summary>
        /// Static field to allign the foodID
        /// </summary>
        private static int s_foodID=100;
        /// <summary>
        /// Get and set the FoodID
        /// </summary>
        /// <value></value>
        public string FoodID { get; set; }
        /// <summary>
        /// Get and set the FoodName
        /// </summary>
        /// <value></value>
        public string FoodName { get; set; }
        /// <summary>
        /// Get and set the Price Per Quantity
        /// </summary>
        /// <value></value>
        public int PricePerQuantity { get; set; }
        /// <summary>
        /// Get and set the Quantity Available
        /// </summary>
        /// <value></value>
        public int QuantityAvailable { get; set; }
        /// <summary>
        /// Constructor class that fetch data form creating the object of the class
        /// </summary>
        /// <param name="foodName"></param>
        /// <param name="pricePerQuantity"></param>
        /// <param name="quantityAvailable"></param>
        public FoodDetails(string foodName,int pricePerQuantity,int quantityAvailable)
        {
            FoodID="FID"+(++s_foodID);
            FoodName=foodName;
            PricePerQuantity=pricePerQuantity;
            QuantityAvailable=quantityAvailable;
        }

        /// <summary>
         /// Food Detail constructor that reads the data in the csv file
         /// </summary>
         /// <param name="data">data that used to read the data in csv file</param>
        public FoodDetails(string data)
        {
            string[] values= data.Split(",");
            s_foodID=int.Parse(values[0].Remove(0,3));
            FoodID=values[0];
            FoodName=values[1];
            PricePerQuantity=int.Parse(values[2]);
            QuantityAvailable=int.Parse(values[3]);
        }
    }
}