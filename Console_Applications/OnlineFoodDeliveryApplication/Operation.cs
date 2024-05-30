using System;


namespace OnlineFoodDeliveryApplication
{

    public partial class Operation
    {
        public static List<CustomerDetails> customerDetails = new List<CustomerDetails>();
        public static List<FoodDetails> foodDetails = new List<FoodDetails>();
        public static List<OrderDetails> orderDetails = new List<OrderDetails>();
        public static List<ItemDetails> itemDetails = new List<ItemDetails>();

        public static CustomerDetails currentCustomer;
        public static event EventManager customerRegistration,customerLogin,subMenu,showProfile,orderFood,cancelOrder,orderHistory,rechargeWallet,showBalance;

        public static void Subscribe()
        {
            customerRegistration=new EventManager(CustomerRegistration);
            customerLogin=new EventManager(CustomerLogin);
            subMenu=new EventManager(SubMenu);
            showProfile=new EventManager(ShowProfile);
            orderFood=new EventManager(OrderFood);
            cancelOrder=new EventManager(CancelOrder);
            orderHistory=new EventManager(OrderHistory);
            rechargeWallet=new EventManager(RechargeWallet);
            showBalance=new EventManager(ShowBalance);

        }


        // Main menu holds the list of operation in the Main page.
        // We can select the operation by entering the integers.
        public static void MainMenu()
        {
            int option;
            do{
                    System.Console.WriteLine();
                    System.Console.WriteLine("****** (: ONLINE FOOD DELIVERY APPLICATION :) ******");
                    System.Console.WriteLine();
                    System.Console.WriteLine("Select \n 1.Customer Registration \n 2.Customer Login \n 3.Exit");
                    System.Console.Write("Select the option: ");
                    option=int.Parse(Console.ReadLine());
                    switch(option)
                    {
                            case 1:
                            {
                                customerRegistration();
                                break;
                            }
                            case 2:
                            {
                                customerLogin();
                                break;
                            }
                            case 3:
                            {
                                break;
                            }
                    }
            }while(option!=3);
        }
        // Customer Registration ask all the details and it will create you a new registration in application. 
        public static void CustomerRegistration()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("******* (: CUSTOMER REGISTRATION :) *******");
            System.Console.WriteLine();


            System.Console.Write("Enter the Name: ");
            string name=Console.ReadLine();

            System.Console.Write("Enter the Father Name: ");
            string fatherName=Console.ReadLine();

            System.Console.Write("Enter the Gender: ");
            Gender gender=Enum.Parse<Gender>(Console.ReadLine(),true);

            System.Console.Write("Enter the Mobile Number: ");
            long mobileNumber=long.Parse(Console.ReadLine());

            System.Console.Write("Enter the DOB(dd/MM/yyyy): ");
            DateTime dob= DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);

            System.Console.Write("Enter the MailID: ");
            string mailID=Console.ReadLine();

            System.Console.Write("Enter the Location: ");
            string location=Console.ReadLine();

            System.Console.Write("Enter the Balance to add initially: ");
            int balance= int.Parse(Console.ReadLine());

            CustomerDetails customer = new CustomerDetails(balance,name,fatherName,gender,mobileNumber,dob,mailID,location);
            customerDetails.Add(customer);
           
            System.Console.WriteLine();
            System.Console.WriteLine("****** (: REGISTERED SUCCESSFULY :) ******");
            System.Console.WriteLine();
            System.Console.WriteLine("Your Customer ID is "+customer.CustomerID);
            System.Console.WriteLine();
        }

        //After selecting the customerlogin from the choice it will ask the login ID to enter and it will check your customer ID is valid or not. 
        //After matching the vaid the valid credential it will call the submenu.
        public static void CustomerLogin()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("****** (: LOGIN PAGE :) ******");
            System.Console.WriteLine();
            System.Console.Write("Enter the customerID to login: ");
            string userCustomerID=Console.ReadLine().ToUpper();
            bool flag = true;
            foreach(CustomerDetails customer in customerDetails)
            {
                if(customer.CustomerID==userCustomerID)
                {
                    flag=false;
                    System.Console.WriteLine("******  (: Successfully Logined :) ******");
                    currentCustomer=customer;
                    subMenu();
                }
            }
            if(flag)
            {
                System.Console.WriteLine("***** (: Invalid CustomerID :) *****");
            }            
        }

        // Submenu displays some operation and it call the booking,cancelling and displaying Details.
        public static void SubMenu()
        {
            char choice;
            do{
                System.Console.WriteLine();
                System.Console.WriteLine("****** (: SubMenu :) *******");
                System.Console.WriteLine();
                
                System.Console.WriteLine("Select \n a.Show Profile \n b.Order Food \n c.Cancel Order \n d.Order History \n e.Recharge Wallet \n f.Show Balance \n g.Exit");
                System.Console.Write("Enter the character to select: ");
                choice=Char.Parse(Console.ReadLine());

                switch(choice)
                {
                    case 'a':
                    {
                        showProfile();
                        break;
                    }
                    case 'b':
                    {
                        orderFood();
                        break;
                    }
                    case 'c':
                    {
                        cancelOrder();
                        break;
                    }
                    case 'd':
                    {
                        orderHistory();
                        break;
                    }
                    case 'e':
                    {
                        rechargeWallet();
                        break;
                    }
                    case 'f':
                    {
                        showBalance();
                        break;
                    }
                    case 'g':
                    {
                        break;
                    }
                }
            }while(choice!='g');
        }

        //Show profile display the profile of current user logined
        public static void ShowProfile()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("****** (: SHOW PROFILE :) *****");
            System.Console.WriteLine();
            System.Console.WriteLine( "|-----------------------------------------------------------------------------------------------------------------|");
            System.Console.WriteLine( "| CustomerID | Balance | Name | Father Name | Gender | Mobile Number | Dathe OF Birth |    Mail ID     | Location |");
            foreach(CustomerDetails customer in customerDetails)
            {
                if(customer.CustomerID==currentCustomer.CustomerID)
                {
                    System.Console.WriteLine( "|-----------------------------------------------------------------------------------------------------------------|");

                    System.Console.WriteLine($"| {customer.CustomerID.PadRight(10)} | {customer.Balance.ToString().PadRight(7)} | {customer.Name.PadRight(4)} | {customer.FatherName.PadRight(11)} | {customer.Gender.ToString().PadRight(6)} | {customer.MobileNumber.ToString().PadRight(12)} | {customer.DOB.ToString("dd/MM/yyyy").ToString().PadRight(14)} | {customer.MailID.PadRight(13)} | {customer.Location.PadRight(8)} |");
                    System.Console.WriteLine( "|-----------------------------------------------------------------------------------------------------------------|");

                }
            }
        }

        //Order history which diplays all the order history of current logined user.
        public static void OrderHistory()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("***** (: ORDER HISTORY :) ******");
            System.Console.WriteLine();
            System.Console.WriteLine( "|---------------------------------------------------------------------| " );
            System.Console.WriteLine( "| Order ID | Customer ID | Total Price | Date OF Order | Order Status |");
            foreach(OrderDetails order in orderDetails)
            {
               
                if(order.CustomerID==currentCustomer.CustomerID)
                {
                    System.Console.WriteLine( "|---------------------------------------------------------------------| " );
                    System.Console.WriteLine($"| {order.OrderID.PadRight(8) } | {order.CustomerID.PadRight(11)} | {order.TotalPrice.ToString().PadRight(11)} | {order.DateOfOrder.ToString("dd/MM/yyyy").PadRight(13)} | {order.OrderStatus.ToString().PadRight(11)}  |");
                    System.Console.WriteLine( "|---------------------------------------------------------------------| " );
                }
            }
        }

    // Recharge wallet ask the users to enter the money and it will add the money to your account.
        public static void RechargeWallet()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("***** (: RECHARGE WALLET :) ******");
            System.Console.WriteLine();
            System.Console.Write("Enter the amount to add in the wallet: ");
            double money=int.Parse(Console.ReadLine());
            currentCustomer.WalletRecharge(money);
            System.Console.WriteLine();
            System.Console.WriteLine("****** (:  Money added in wallet Successfully :) ******");
            System.Console.WriteLine();
        }

        // ShowDisplay display the balance of the current user. 
        public static void ShowBalance()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("****** (: SHOW BALANCE :) *******");
            System.Console.WriteLine();
            System.Console.WriteLine("Your balance amount is "+currentCustomer.Balance);
        }

        //Defaultstore stores all the details to the list.
        public static void DefaultStore()
        {
            customerDetails.Add(new CustomerDetails(10000, "Ravi", "Ettapparajan", Gender.Male, 974774646, new DateTime(1999, 11, 11), "ravi@gmail.com", "Chennai"));
            customerDetails.Add(new CustomerDetails(15000, "Baskaran", "Sethurajan", Gender.Male, 847575775, new DateTime(1999, 11, 11), "baskaran@gmail.com", "Chennai"));


            foodDetails.Add(new FoodDetails("Chicken Briyani 1Kg", 100, 12));
            foodDetails.Add(new FoodDetails("Mutton Briyani 1Kg", 150, 10));
            foodDetails.Add(new FoodDetails("Veg Full Meals", 80, 30));
            foodDetails.Add(new FoodDetails("Noodles", 100, 40));
            foodDetails.Add(new FoodDetails("Dosa", 40, 40));
            foodDetails.Add(new FoodDetails("Idly (2 pieces)", 20, 50));
            foodDetails.Add(new FoodDetails("Pongal", 40, 20));
            foodDetails.Add(new FoodDetails("Vegetable Briyani", 80, 15));
            foodDetails.Add(new FoodDetails("Lemon Rice", 50, 30));
            foodDetails.Add(new FoodDetails("Veg Pulav", 120, 30));
            foodDetails.Add(new FoodDetails("Chicken 65 (200 Grams)", 75, 30));


            orderDetails.Add(new OrderDetails("CID1001", 580, new DateTime(2022, 11, 26), OrderStatus.Ordered));
            orderDetails.Add(new OrderDetails("CID1002", 870, new DateTime(2022, 11, 26), OrderStatus.Ordered));
            orderDetails.Add(new OrderDetails("CID1001", 820, new DateTime(2022, 11, 26), OrderStatus.Cancelled));


            itemDetails.Add(new ItemDetails("OID3001", "FID101", 2, 200));
            itemDetails.Add(new ItemDetails("OID3001", "FID102", 2, 300));
            itemDetails.Add(new ItemDetails("OID3001", "FID103", 1, 80));
            itemDetails.Add(new ItemDetails("OID3002", "FID101", 1, 100));
            itemDetails.Add(new ItemDetails("OID3002", "FID102", 4, 600));
            itemDetails.Add(new ItemDetails("OID3002", "FID110", 1, 120));
            itemDetails.Add(new ItemDetails("OID3002", "FID109", 1, 50));
            itemDetails.Add(new ItemDetails("OID3003", "FID102", 2, 300));
            itemDetails.Add(new ItemDetails("OID3003", "FID108", 4, 320));
            itemDetails.Add(new ItemDetails("OID3003", "FID101", 2, 200));
        }
    }
}