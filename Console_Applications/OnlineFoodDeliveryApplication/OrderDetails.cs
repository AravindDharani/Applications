using System;
namespace OnlineFoodDeliveryApplication
{
    public enum OrderStatus{Ordered,Cancelled,Iniated}

    /// <summary>
    /// Class that creates the order Details
    /// </summary>
    public class OrderDetails
    {
        /// <summary>
        /// Static value of Order ID 
        /// </summary>
        private static int s_orderID=3000;
        /// <summary>
        /// get and set the order ID.
        /// </summary>
        /// <value></value>
        public string OrderID { get; set; }
        /// <summary>
        /// get and set the customer ID.
        /// </summary>
        /// <value></value>
        public string CustomerID { get; set; }
        /// <summary>
        /// get and set the Total Price
        /// </summary>
        /// <value></value>
        public double TotalPrice { get; set; }
        /// <summary>
        /// get and set the Date OF order
        /// </summary>
        /// <value></value>
        public DateTime DateOfOrder { get; set; }

        /// <summary>
        /// get and set Date of Order
        /// </summary>
        /// <value></value>
        public OrderStatus OrderStatus { get; set; }
        /// <summary>
        /// Constructor class that fetch data form creating the object of the class
        /// </summary>
        /// <param name="customerID"></param>
        /// <param name="totalPrice"></param>
        /// <param name="dateOfOrder"></param>
        /// <param name="orderStatus"></param>
        public OrderDetails(string customerID,double totalPrice,DateTime dateOfOrder,OrderStatus orderStatus)
        {
            OrderID="OID"+(++s_orderID);
            CustomerID=customerID;
            TotalPrice=totalPrice;
            DateOfOrder=dateOfOrder;
            OrderStatus=orderStatus;
        }
        /// <summary>
         /// order Detail constructor that reads the data in the csv file
         /// </summary>
         /// <param name="data">data that used to read the data in csv file</param>
        public OrderDetails(string data)
        {
            string[] values= data.Split(",");
            s_orderID=int.Parse(values[0].Remove(0,3));
            OrderID=values[0];
            CustomerID=values[1];
            TotalPrice=double.Parse(values[2]);
            DateOfOrder=DateTime.ParseExact(values[3],"dd/MM/yyyy",null);
            OrderStatus=Enum.Parse<OrderStatus>(values[4],true);
        }
    }
}