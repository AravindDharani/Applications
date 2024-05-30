using System;
using System.Collections.Generic;
namespace CafeteriaCardManagement
{
    public partial class Operation
    {
        public static List<UserDetails> userDetails = new List<UserDetails>();
        public static List<FoodDetails> foodDetails = new List<FoodDetails>();
        public static List<OrderDetails> orderDetails = new List<OrderDetails>();
        public static List<CartItems> CartItems = new List<CartItems>();
      
        public static UserDetails currentUser;

        public static event EventManager registration,login,subMenu,showMyProfile,foodOrder,cancelOrder,orderhistory,recharge; 
        public static void Subscribe()
        {
            registration=new EventManager(Operation.UserRegistration);
            login=new EventManager(Operation.Login);
            subMenu=new EventManager(Operation.SubMenu);
            showMyProfile=new EventManager(Operation.ShowMyProfile);
            foodOrder=new EventManager(Operation.FoodOrder);
            cancelOrder=new EventManager(Operation.CancelOrder);
            orderhistory=new EventManager(Operation.OrderHistory);
            recharge=new EventManager(Operation.Recharge);


        }

        public static void MainMenu()
        {
          //  DefaultStore();
            System.Console.WriteLine("******** CafeteriaCardManagement ********");
            int option;
            do
            {
                     System.Console.WriteLine("****** Main Menu *******");
                     System.Console.WriteLine("Select: \n 1.User Registration \n 2.User Login \n 3.Exit");
                     System.Console.Write("Enter the option to select: ");
                     option=int.Parse(Console.ReadLine());
                     switch(option)
                     {
                        case 1:
                        {
                            registration();
                            break;
                            }
                        case 2:
                        {
                            login();
                            break;
                        }
                        case 3:
                        {
                            break;
                            }
                     }

            }while(option!=3);

        }

        public static void UserRegistration()
        {
            System.Console.WriteLine("****** Registration Page *******");

            System.Console.Write("Enter the name: ");
            string name=Console.ReadLine();
            System.Console.Write("Enter the Father name: ");
            string fatherName=Console.ReadLine();
            System.Console.Write("Enter the mobile number: ");
            long mobile=long.Parse(Console.ReadLine());
            System.Console.Write("Enter the mailID: ");
            string mailID=Console.ReadLine();
            System.Console.Write("Enter the Gender: ");
            Gender gender=Enum.Parse<Gender>(Console.ReadLine(),true);
            System.Console.Write("Enter the Work station number: ");
            string workStationNumber=Console.ReadLine();
            System.Console.Write("Enter the Balance to add: ");
            int balance=int.Parse(Console.ReadLine());
            UserDetails userDetail=new UserDetails(name,fatherName,mobile,mailID,gender,workStationNumber,balance);
            userDetails.Add(userDetail);
            System.Console.WriteLine("Registration Successfully created");
            System.Console.WriteLine();
            System.Console.WriteLine("your Registration ID is: "+userDetail.UserID);
            System.Console.WriteLine();

        }

        public static void Login()
        {
            System.Console.Write("Enter your Registration ID to login: ");
            string userID=Console.ReadLine().ToUpper();
            bool flag=true;
            foreach(UserDetails userDetail in userDetails)
            {
                if(userDetail.UserID==userID)
                {
                    flag=false;
                    currentUser=userDetail;
                    SubMenu();
                }
            }
            if(flag)
            {
                System.Console.WriteLine("Invallid UserID");
            }
        }

        public static void SubMenu()
        {
           char choice;
            do{
                 System.Console.WriteLine("****** SubMenu *******");
                 System.Console.WriteLine("Select \n a.Show My Profile \n b.Food Order \n c.Cancel Order \n d.Order History \n e.Wallet Recharge \n f.Exit");
                    System.Console.Write("Enter your choice: ");
                   choice=char.Parse(Console.ReadLine());
                switch(choice)
                {
                    case 'a':
                    {
                        showMyProfile();
                        break;
                    }
                    case 'b':
                    {
                        foodOrder();
                        break;
                    }
                    case 'c':
                    {
                        cancelOrder();
                        break;
                    }
                    case 'd':
                    {
                        orderhistory();
                        break;
                    }
                    case 'e':
                    {
                        recharge();
                        break;
                    }
                    case 'f':
                    {
                        break;
                    }
                    }
            }while(choice!='f');
        }

        public static void ShowMyProfile()
        {
            System.Console.WriteLine(currentUser.UserID+" "+currentUser.Name+"  "+currentUser.FatherName+"  "+currentUser.Mobile+"  "+currentUser.Gender+"  "+currentUser.MailID+"  "+currentUser.WorkStationNumber+"  "+currentUser.Balance);
        }
       



        public static void OrderHistory()
        {
            foreach(OrderDetails orderDetail in orderDetails)
            {
                if(orderDetail.UserID==currentUser.UserID)
                {
                    System.Console.WriteLine(orderDetail.OrderID+"  "+orderDetail.UserID+"  "+orderDetail.OrderDate.ToString("dd/MM/yyyy")+"  "+orderDetail.TotalPrice+"  "+orderDetail.OrderStatus);
                }
            }
        }

        public static void Recharge()
        {
            System.Console.Write("Enter the amount to recharge: ");
            int money=int.Parse(Console.ReadLine());
            currentUser.WalletRecharge(money);
        }
        public static void DefaultStore()
        {
            userDetails.Add(new UserDetails("Ravichandran", "Ettapparajan", 8857777575, "ravi@gmail.com", Gender.Male, "WS101", 400));
            userDetails.Add(new UserDetails("Baskaran", "Sethurajan", 9577747744, "baskaran@gmail.com", Gender.Male, "WS105", 500));
            foodDetails.Add(new FoodDetails("Coffee", 20, 100));
            foodDetails.Add(new FoodDetails("Tea", 15, 100));
            foodDetails.Add(new FoodDetails("Biscuit", 10, 100));
            foodDetails.Add(new FoodDetails("Juice", 50, 100));
            foodDetails.Add(new FoodDetails("Puff", 40, 100));
            foodDetails.Add(new FoodDetails("Milk", 10, 100));
            foodDetails.Add(new FoodDetails("Popcorn", 20, 10));

            orderDetails.Add(new OrderDetails("SF1001", new DateTime(2022, 06, 15), 70, OrderStatus.Ordered));
            orderDetails.Add(new OrderDetails("SF1002", new DateTime(2022, 06, 15), 70, OrderStatus.Ordered));
            CartItems.Add(new CartItems("OID1001", "FID101", 20, 1));
            CartItems.Add(new CartItems("OID1001", "FID103", 10, 1));
            CartItems.Add(new CartItems("OID1001", "FID105", 40, 1));
            CartItems.Add(new CartItems("OID1002", "FID103", 10, 1));
            CartItems.Add(new CartItems("OID1002", "FID104", 50, 1));
            CartItems.Add(new CartItems("OID1002", "FID105", 40, 1));



        }
    }
}