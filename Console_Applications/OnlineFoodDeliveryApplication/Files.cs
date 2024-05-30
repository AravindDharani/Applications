using System.IO;
namespace OnlineFoodDeliveryApplication
{
    public class Files
    {
        /// <summary>
        /// Method that used to create the folder and file as csv
        /// </summary>
        public static void Create()
        {
            if(!Directory.Exists("OnlineFoodDeliveryApplication"))
            {
                System.Console.WriteLine("Directory created");
                Directory.CreateDirectory("OnlineFoodDeliveryApplication");
            }
            else
            {
                System.Console.WriteLine("Directory already exist");
            }

            if(!File.Exists("OnlineFoodDeliveryApplication/CustomerDetails.csv"))
            {
                System.Console.WriteLine("File created");
                File.Create("OnlineFoodDeliveryApplication/CustomerDetails.csv").Close();
            }
            else
            {
                System.Console.WriteLine("File already exist");
            }

            if(!File.Exists("OnlineFoodDeliveryApplication/OrderDetails.csv"))
            {
                System.Console.WriteLine("File created");
                File.Create("OnlineFoodDeliveryApplication/OrderDetails.csv").Close();
            }
            else
            {
                System.Console.WriteLine("File already exist");
            }

            if(!File.Exists("OnlineFoodDeliveryApplication/FoodDetails.csv"))
            {
                System.Console.WriteLine("File created");
                File.Create("OnlineFoodDeliveryApplication/FoodDetails.csv").Close();
            }
            else
            {
                System.Console.WriteLine("File already exist");
            }


            if(!File.Exists("OnlineFoodDeliveryApplication/ItemDetails.csv"))
            {
                System.Console.WriteLine("File created");
                File.Create("OnlineFoodDeliveryApplication/ItemDetails.csv").Close();
            }
            else
            {
                System.Console.WriteLine("File already exist");
            }
        }
        /// <summary>
        /// File that used to write the data from list to csv file
        /// </summary>
        public static void WriteToFile()
        {
            string[] customer = new string[Operation.customerDetails.Count];
            for(int i=0;i<Operation.customerDetails.Count;i++)
            {
                customer[i]=Operation.customerDetails[i].CustomerID+","+Operation.customerDetails[i].Balance+","+Operation.customerDetails[i].Name+","+Operation.customerDetails[i].FatherName+","+Operation.customerDetails[i].Gender+","+Operation.customerDetails[i].MobileNumber+","+Operation.customerDetails[i].DOB.ToString("dd/MM/yyyy")+","+Operation.customerDetails[i].MailID+","+Operation.customerDetails[i].Location;
            }
            File.WriteAllLines("OnlineFoodDeliveryApplication/CustomerDetails.csv",customer);

            string[] order = new string[Operation.orderDetails.Count];
            for(int i=0;i<Operation.orderDetails.Count;i++)
            {
                order[i]=Operation.orderDetails[i].OrderID+","+Operation.orderDetails[i].CustomerID+","+Operation.orderDetails[i].TotalPrice+","+Operation.orderDetails[i].DateOfOrder.ToString("dd/MM/yyyy")+","+Operation.orderDetails[i].OrderStatus;
            }
            File.WriteAllLines("OnlineFoodDeliveryApplication/OrderDetails.csv",order);

            string[] food = new string[Operation.foodDetails.Count];
            for(int i=0;i<Operation.foodDetails.Count;i++)
            {
                food[i]=Operation.foodDetails[i].FoodID+","+Operation.foodDetails[i].FoodName+","+Operation.foodDetails[i].PricePerQuantity+","+Operation.foodDetails[i].QuantityAvailable;
            }
            File.WriteAllLines("OnlineFoodDeliveryApplication/FoodDetails.csv",food);


            string[] item = new string[Operation.itemDetails.Count];
            for(int i=0;i<Operation.itemDetails.Count;i++)
            {
                item[i]=Operation.itemDetails[i].ItemID+","+Operation.itemDetails[i].OrderID+","+Operation.itemDetails[i].FoodID+","+Operation.itemDetails[i].PurchaseCount+","+Operation.itemDetails[i].PriceOfOrder;
            }
            File.WriteAllLines("OnlineFoodDeliveryApplication/ItemDetails.csv",item);
        }
        /// <summary>
        /// Read file method that read the data from CSV file to class.
        /// </summary>
        public static void ReadFile()
        {
            string[] customer = File.ReadAllLines("OnlineFoodDeliveryApplication/CustomerDetails.csv");
            foreach(string data in customer)
            {
                CustomerDetails customers = new CustomerDetails(data);
                Operation.customerDetails.Add(customers);
            }

             string[] order = File.ReadAllLines("OnlineFoodDeliveryApplication/OrderDetails.csv");
            foreach(string data in order)
            {
                OrderDetails orders = new OrderDetails(data);
                Operation.orderDetails.Add(orders);
            }

             string[] food = File.ReadAllLines("OnlineFoodDeliveryApplication/FoodDetails.csv");
            foreach(string data in food)
            {
                FoodDetails foods = new FoodDetails(data);
                Operation.foodDetails.Add(foods);
            }

             string[] item = File.ReadAllLines("OnlineFoodDeliveryApplication/ItemDetails.csv");
            foreach(string data in item)
            {
                ItemDetails items = new ItemDetails(data);
                Operation.itemDetails.Add(items);
            }

        }
    }
}