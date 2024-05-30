using System;
namespace CafeteriaCardManagement
{
    public partial class Operation
    {



        public static void FoodOrder()
        {
            List<CartItems> localCartItem = new List<CartItems>();
            OrderDetails orderDetail = new OrderDetails(currentUser.UserID, DateTime.Now, 0, OrderStatus.Iniated);
            // orderDetails.Add(orderDetail);
            // string userAnotherOrder = null;
            string orderConfirm;
            bool userFlag = true;
            int totalAmount = 0;
            do
            {

                foreach (FoodDetails foodDetail in foodDetails)
                {
                    System.Console.WriteLine(foodDetail.FoodID + "  " + foodDetail.FoodName + "  " + foodDetail.FoodPrice + "  " + foodDetail.FoodQuantity);
                }
                System.Console.Write("Select the food using foodID: ");
                string userFoodID = Console.ReadLine().ToUpper();
                System.Console.Write("Select the food Quantity: ");
                int userQuantity = int.Parse(Console.ReadLine());
                foreach (FoodDetails foodDetail in foodDetails)
                {
                    if (foodDetail.FoodID == userFoodID)
                    {
                        userFlag = false;
                        if (foodDetail.FoodQuantity > userQuantity)
                        {
                            System.Console.WriteLine("Count Available");
                            foodDetail.FoodQuantity -= userQuantity;
                            int amount = userQuantity * foodDetail.FoodPrice;
                            totalAmount += amount;
                            CartItems cartItem = new CartItems(orderDetail.OrderID, foodDetail.FoodID, totalAmount, userQuantity);
                           localCartItem.Add(cartItem);
                        }
                        else
                        {
                            System.Console.WriteLine("Count not available");
                        }
                    }
                }
                if (userFlag)
                {
                    System.Console.WriteLine("Invalid Food ID");
                }
                System.Console.Write("Do you like to purchase more(Yes/No): ");
                orderConfirm = Console.ReadLine().ToUpper();
            } while (orderConfirm == "YES");

            System.Console.Write("Do you want to confirm your order(yes/no)");
            string userConfirmOrder = Console.ReadLine().ToLower();
            if (userConfirmOrder == "yes")
            {
                bool flag = false;
                string userRecharge;
                do
                {
                    if (totalAmount <= currentUser.Balance)
                    {
                        flag = true;
                        currentUser.Deduct(totalAmount);
                        orderDetail.TotalPrice = totalAmount;
                        orderDetail.OrderStatus = OrderStatus.Ordered;
                        orderDetails.Add(orderDetail);
                        CartItems.AddRange(localCartItem);
                        System.Console.WriteLine("Purchase Successfully confirmed"+orderDetail.OrderID);

                    }
                    else
                    {

                        System.Console.WriteLine("Insuficient Balance Recharge the " + totalAmount);
                        System.Console.Write("Do you continue with recharge: ");
                        userRecharge = Console.ReadLine();
                        if (userRecharge == "yes")
                        {
                            System.Console.Write("Enter the amount to recharge: ");
                            int money = int.Parse(Console.ReadLine());
                            currentUser.WalletRecharge(money);
                        }
                        else
                        {
                            System.Console.WriteLine("Exiting without recharge");
                            flag = true;
                        }
                    }

                } while (!flag);
            }
            else
                {
                        foreach(CartItems cart in localCartItem)
                        {
                            foreach (FoodDetails food in foodDetails)
                            {
                                if (cart.FoodID == food.FoodID)
                                 {
                                        food.FoodQuantity += cart.OrderQuantity;
                                        System.Console.WriteLine("Returned in shop");
                                }
                            }
                        }
                }

        }

        public static void CancelOrder()
        {
            string userCancelID;
            foreach(OrderDetails orderDetail in orderDetails)
            {
              
                    if(currentUser.UserID==orderDetail.UserID && orderDetail.OrderStatus==OrderStatus.Ordered)
                    {
                        System.Console.WriteLine(orderDetail.OrderID+"  "+orderDetail.UserID+"  "+orderDetail.OrderDate.ToString("dd/MM/yyyy")+"  "+orderDetail.TotalPrice+"  "+orderDetail.OrderStatus);

                    }
                
            }
            System.Console.Write("Enter cancel ID to be cancel: ");
            userCancelID=Console.ReadLine();
             foreach(OrderDetails orderDetail in orderDetails)
            {
                if(currentUser.UserID==orderDetail.UserID && orderDetail.OrderStatus==OrderStatus.Ordered)
                {
                    orderDetail.OrderStatus=OrderStatus.Cancelled;
                    foreach(CartItems cart in CartItems)
                    {
                        if(cart.OrderID==orderDetail.OrderID)
                        {
                            foreach(FoodDetails food in foodDetails)
                            {
                                if(food.FoodID==cart.FoodID)
                                {
                                    food.FoodQuantity+=cart.OrderQuantity;
                                    System.Console.WriteLine("your returned material is "+food.FoodName);
                                }
                            }
                        }
                    }
                    currentUser.WalletRecharge(orderDetail.TotalPrice);
                    orderDetail.OrderStatus=OrderStatus.Cancelled;
                    System.Console.WriteLine("Ordered cancelled successfuly");
                    System.Console.WriteLine("Cancelled ordered is "+orderDetail.OrderID);
                }

            }

            
        }

    }
}