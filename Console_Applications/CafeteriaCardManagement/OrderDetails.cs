using System;
namespace CafeteriaCardManagement
{
    public enum OrderStatus{Default,Iniated,Ordered,Cancelled}
    public class OrderDetails
    { 
        public static int s_orderID=1000;
        public string OrderID { get; set; }
        public string UserID { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalPrice { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public OrderDetails(string userID,DateTime orderDate,int totalPrice,OrderStatus orderStatus)
        {
            OrderID="OID"+(++s_orderID);
            UserID=userID;
            OrderDate=orderDate;
            TotalPrice=totalPrice;
            OrderStatus=orderStatus;
        }

        public OrderDetails(string data)
        {
            string[] values= data.Split(",");
            s_orderID=int.Parse(values[0].Remove(0,3));
            OrderID=values[0];
            UserID=values[1];
            OrderDate=DateTime.ParseExact(values[2],"dd/MM/yyyy",null);
            TotalPrice=int.Parse(values[3]);
            OrderStatus=Enum.Parse<OrderStatus>(values[4],true);

        }

    }
    }
