using System.IO.Enumeration;
using System;
namespace OnlineFoodDeliveryApplication
{
    public partial class Operation
    {
        //Creating the Order detail object as current customerid datetime as now orderstatus as iniated.
        //Create the list for local itemsDetail
        //Traversing and displaying all the food details
        //Asking the user to enter the food id and quantity need.
        //check the food id which is given by the user
        //If it is available then, create ItemDetails object with created OrderID, FoodID, Quantity and Price of this order
        //deduct the available quantity and store in localItemList.
        //Calculate total price of this Order by summing it with current item price. 
        //Ask the user whether he want to order more. If yes means again show food details
        //If user select no then show Do you want to confirm purchase.
        //If he says no return the localItemList of items count back to FoodDetails list. 
        //Check whether the customer wallet has sufficient balance.
        //If he has balance then, redo the  OrderDetails object which was created at early with TotalPrice and OrderStatus to Ordered.
        // Deduct hte total amount int the balance of the current user.
        //If the balance is less inform the customer that the wallet has less balance and whether wish to recharge or not.
        //If user says No return the localItemList item count to FoodList.
        //if user say yes deduct the amount from the current user

        public static void OrderFood()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("****** (: ORDER FOOD :) ******");
            System.Console.WriteLine();
            OrderDetails order = new OrderDetails(currentCustomer.CustomerID, 0, DateTime.Now, OrderStatus.Iniated);
            List<ItemDetails> localItemDetails = new List<ItemDetails>();
            string userReentry;
            int userQuantity, totalAmount = 0;
            string userFoodID;
            string userRecharge;
            do
            {
                System.Console.WriteLine( "|-----------------------------------------------------------------------------------|");
                System.Console.WriteLine( "| Food ID |           Food Name           | Price per Quantity | Quantity Available |");
                foreach (FoodDetails food in foodDetails)
                {
                    System.Console.WriteLine( "|-----------------------------------------------------------------------------------|");
                    System.Console.WriteLine($"| {food.FoodID.PadRight(7)} | {food.FoodName.PadRight(29)} | {food.PricePerQuantity.ToString().PadRight(18)} | {food.QuantityAvailable.ToString().PadRight(18)} |");
                    System.Console.WriteLine( "|-----------------------------------------------------------------------------------|");
                }
                System.Console.Write("Enter the Food using FoodID: ");
                userFoodID = Console.ReadLine().ToUpper();
                System.Console.Write("Enter the quantity of the food: ");
                userQuantity = int.Parse(Console.ReadLine());
                bool flag = true;

                foreach (FoodDetails food in foodDetails)
                {
                    if (food.FoodID == userFoodID)
                    {
                        flag = false;
                        if (food.QuantityAvailable > userQuantity)
                        {
                            totalAmount += food.PricePerQuantity * userQuantity;
                            food.QuantityAvailable -= userQuantity;
                            ItemDetails item = new ItemDetails(order.OrderID, food.FoodID, userQuantity, food.PricePerQuantity * userQuantity);
                            localItemDetails.Add(item);
                            System.Console.WriteLine("***** (: Food added to the cart :) *******");

                        }
                        else
                        {
                            System.Console.WriteLine("******* (: Food quantity unavailble :) *******");
                        }

                    }
                }
                if (flag)
                {
                    System.Console.WriteLine("Invalid FoodID");
                }

                System.Console.Write("Do you want to buy the food again(say Yes/No): ");
                userReentry = Console.ReadLine().ToUpper();
            } while (userReentry == "YES");
            bool userFlag = false;
            System.Console.Write("Do you want to confirm the order(Say yes/No)");
            string userConfirmOrder = Console.ReadLine().ToUpper();
            if (userConfirmOrder == "YES")
            {
                do
                {
                    if (currentCustomer.Balance >= totalAmount)
                    {
                        userFlag = true;
                        order.TotalPrice = totalAmount;
                        order.OrderStatus = OrderStatus.Ordered;
                        orderDetails.Add(order);
                        currentCustomer.DeductBalance(totalAmount);
                        itemDetails.AddRange(localItemDetails);
                        System.Console.WriteLine("***** (: Ordered succeffuly Done :) *****");
                    }
                    else
                    {
                        System.Console.WriteLine("Insufficient Balance");
                        System.Console.WriteLine("Insuficient Balance Recharge the amount as " + totalAmount);
                        System.Console.Write("Do you continue with recharge(say yes/no): ");
                        userRecharge = Console.ReadLine().ToUpper();
                        if (userRecharge == "YES")
                        {
                            System.Console.Write("Enter the amount to recharge: ");
                            int money = int.Parse(Console.ReadLine());
                            currentCustomer.WalletRecharge(money);
                            System.Console.WriteLine("Your balane amount is " + currentCustomer.Balance);
                        }
                        else
                        {
                            foreach (ItemDetails item in localItemDetails)
                            {
                                foreach (FoodDetails food in foodDetails)
                                {
                                    if (item.FoodID == item.FoodID)
                                    {
                                        food.QuantityAvailable += item.PurchaseCount;
                                        System.Console.WriteLine("**** (: Returned succeessfully :) *****");
                                    }
                                }
                            }
                            System.Console.WriteLine("Exiting without recharge");

                            userFlag = true;
                        }
                    }
                } while (!userFlag);
            }
            else
            {
                foreach (ItemDetails item in localItemDetails)
                {
                    foreach (FoodDetails food in foodDetails)
                    {
                        if (item.FoodID == item.FoodID)
                        {
                            food.QuantityAvailable += item.PurchaseCount;
                            System.Console.WriteLine("**** (: Returned succeessfully :) *****");
                        }
                    }
                }

            }
        }
        // Show the list of Orders placed by current logged in user whose status is ordered.
        // Ask the user to pick a Order id. If Order id is present, then change the Order status to Cancelled. 
        // Refund the total price amount of current Order to user WalletBalance then return the food items of the current Order to FoodList. 
        public static void CancelOrder()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("****** (: CANCEL ORDER :) *****");    
            System.Console.WriteLine();
            System.Console.WriteLine( "|---------------------------------------------------------------------| " );
            System.Console.WriteLine( "| Order ID | Customer ID | Total Price | Date OF Order | Order Status |");
            foreach (OrderDetails order in orderDetails)
            {
                if (order.CustomerID == currentCustomer.CustomerID && order.OrderStatus == OrderStatus.Ordered)
                {
                    System.Console.WriteLine( "|---------------------------------------------------------------------| " );
                    System.Console.WriteLine($"| {order.OrderID.PadRight(8) } | {order.CustomerID.PadRight(11)} | {order.TotalPrice.ToString().PadRight(11)} | {order.DateOfOrder.ToString("dd/MM/yyyy").PadRight(13)} | {order.OrderStatus.ToString().PadRight(11)}  |");
                    System.Console.WriteLine( "|---------------------------------------------------------------------| " );
                }
            }
            System.Console.Write("Enter the orderID to cancel: ");
            string userOrderID = Console.ReadLine().ToUpper();
            bool orderfalg=true;
            foreach (OrderDetails order in orderDetails)
            {
                if (order.OrderID == userOrderID && order.OrderStatus == OrderStatus.Ordered)
                {
                    orderfalg=false;
                    order.OrderStatus = OrderStatus.Cancelled;
                    currentCustomer.DeductBalance(order.TotalPrice);
                    foreach (ItemDetails item in itemDetails)
                    {
                        if(order.OrderID==item.OrderID)
                        {
                            foreach (FoodDetails food in foodDetails)
                            {
                                if (food.FoodID == item.FoodID)
                                {
                                    food.QuantityAvailable += item.PurchaseCount;
                                    
                                }
                            }
                        }
                    }
                     System.Console.WriteLine("****** (: Ordered cancelled successfully :) ******");
                }
            }
            if(orderfalg)
            {
                System.Console.WriteLine("Invalid orderID");
            }
        }

    }
}