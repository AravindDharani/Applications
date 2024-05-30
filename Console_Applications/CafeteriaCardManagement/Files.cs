using System.IO;
namespace CafeteriaCardManagement
{
    public class Files
    {
        public static void create()
        {
            if(!Directory.Exists("CafeteriaCardManagement"))
            {
                System.Console.WriteLine("Directory Created");
                Directory.CreateDirectory("CafeteriaCardManagement");
            }
            else
            {
                System.Console.WriteLine("Directory already Exist");
            }
            if(!File.Exists("CafeteriaCardManagement/UserDetails.csv"))
            {
                System.Console.WriteLine("File created.");
                File.Create("CafeteriaCardManagement/UserDetails.csv").Close();
            }
            else
            {
                System.Console.WriteLine("File already Exist");
            }
            if(!File.Exists("CafeteriaCardManagement/FoodDetails.csv"))
            {
                System.Console.WriteLine("File created");
                File.Create("CafeteriaCardManagement/FoodDetails.csv");
            }
            else
            {
                System.Console.WriteLine("File already exist");
            }
            if(!File.Exists("CafeteriaCardManagement/OrderDetails.csv"))
            {
                System.Console.WriteLine("File");
                File.Create("CafeteriaCardManagement/OrderDetails.csv");
            }
            else
            {
                System.Console.WriteLine("File Already exist");
            }
            if(!File.Exists("CafeteriaCardManagement/GlobalCartItem.csv"))
            {
                System.Console.WriteLine("File created");
                File.Create("CafeteriaCardManagement/GlobalCartItem.csv");
            }
            else
            {
                System.Console.WriteLine("File already exist");
            }

        }

        public static void WriteToFile()
        {
            string[] userDetail = new string[Operation.userDetails.Count];
            for(int i=0;i<Operation.userDetails.Count;i++)
            {
                userDetail[i]=Operation.userDetails[i].UserID+","+Operation.userDetails[i].Name+","+Operation.userDetails[i].FatherName+","+Operation.userDetails[i].Mobile+","+Operation.userDetails[i].MailID+","+Operation.userDetails[i].Gender+","+Operation.userDetails[i].WorkStationNumber+","+Operation.userDetails[i].Balance;
            }
            File.WriteAllLines("CafeteriaCardManagement/UserDetails.csv",userDetail);

            string[] orderDetail= new string[Operation.orderDetails.Count];
            for(int i=0;i<Operation.orderDetails.Count;i++)
            {
                orderDetail[i]=Operation.orderDetails[i].OrderID+","+Operation.orderDetails[i].UserID+","+Operation.orderDetails[i].OrderDate.ToString("dd/MM/yyyy")+","+Operation.orderDetails[i].TotalPrice+","+Operation.orderDetails[i].OrderStatus;
            }
            File.WriteAllLines("CafeteriaCardManagement/OrderDetails.csv",orderDetail);

            string[] foodDetail = new string[Operation.foodDetails.Count];
            for(int i=0;i<Operation.foodDetails.Count;i++)
            {
                foodDetail[i]=Operation.foodDetails[i].FoodID+","+Operation.foodDetails[i].FoodName+","+Operation.foodDetails[i].FoodPrice+","+Operation.foodDetails[i].FoodQuantity;
            }
            File.WriteAllLines("CafeteriaCardManagement/FoodDetails.csv",foodDetail);

            string[] globalCart = new string[Operation.CartItems.Count];
            for(int i=0;i<Operation.CartItems.Count;i++)
            {
                globalCart[i]=Operation.CartItems[i].ItemID+","+Operation.CartItems[i].OrderID+","+Operation.CartItems[i].FoodID+","+Operation.CartItems[i].OrderPrice+","+Operation.CartItems[i].OrderQuantity;
            }
            File.WriteAllLines("CafeteriaCardManagement/GlobalCartItem.csv",globalCart);
        }

        public static void ReadFiles()
        {
            string[] userDetails = File.ReadAllLines("CafeteriaCardManagement/UserDetails.csv");
            foreach(string data in userDetails)
            {
                UserDetails userList = new UserDetails(data);
                Operation.userDetails.Add(userList);
            } 

            string[] orderdetails = File.ReadAllLines("CafeteriaCardManagement/OrderDEtails.csv");
            foreach(string data in orderdetails)
            {
                OrderDetails orderList = new OrderDetails(data);
                Operation.orderDetails.Add(orderList);
            }

            string[] foodDetail = File.ReadAllLines("CafeteriaCardManagement/FoodDetails.csv");
            foreach(string data in foodDetail)
            {
                FoodDetails foodList = new FoodDetails(data);
                Operation.foodDetails.Add(foodList);
            }
            string[] globalCartDetails = File.ReadAllLines("CafeteriaCardManagement/GlobalCartItem.csv");
            foreach(string data in globalCartDetails)
            {
                CartItems globalCartList = new CartItems(data);
                Operation.CartItems.Add(globalCartList);
            }
        }
    }
}