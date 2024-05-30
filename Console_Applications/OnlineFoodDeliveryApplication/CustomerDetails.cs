using System;
namespace OnlineFoodDeliveryApplication
{
   /// <summary>
   /// Customer Detail Class inherits the Personal detail class and IBalance Interface.
   /// Class the creates the USer Details.
   /// </summary>
    public class CustomerDetails:PersonalDetails,IBalance
    {
      /// <summary>
      /// static field for customer ID to Increment.
      /// </summary>
        private static int s_customerID=1000;
        /// <summary>
        /// Property for storing the CustomerID 
        /// </summary>
        /// <value>return and set the Customer ID</value>
        public string CustomerID { get; set; }
         /// <summary>
         /// field for storing _balance to Balance
         /// </summary>
        private double _balance;
         /// <summary>
         /// property that return only thebalance and not allowed to set the balance
         /// </summary>
         /// <value></value>
        public double Balance { get {return _balance;}  }
         /// <summary>
         /// Method for Recharging the money to the balance.
         /// </summary>
         /// <param name="money">parameter for money to add</param>
        public void WalletRecharge(double money)
        {
            _balance+=money;
        }

        /// <summary>
        /// Method for deducting the money to the balance.
        /// </summary>
        /// <param name="money">parameter for money to deduct</param>
        public  void DeductBalance(double money)
         {
            _balance-=money;
         }
         /// <summary>
         /// Constructor class that fetch data form creating the object of the class
         /// </summary>
         /// <param name="money"></param>
         /// <param name="name"></param>
         /// <param name="fatherName"></param>
         /// <param name="gender"></param>
         /// <param name="phoneNumber"></param>
         /// <param name="dob"></param>
         /// <param name="mailID"></param>
         /// <param name="location"></param>
         /// <returns></returns>
         public CustomerDetails(double money,string name, string fatherName,Gender gender,long phoneNumber,DateTime dob,string mailID,string location):base( name,fatherName,gender,phoneNumber,dob,mailID,location)
         {
            CustomerID="CID"+(++s_customerID);
            _balance=money;
         }
         /// <summary>
         /// Customer Detail constructor that reads the data in the csv file
         /// </summary>
         /// <param name="data">data that used to read the data in csv file</param>
         public CustomerDetails(string data)
         {
            string[] values= data.Split(",");
            s_customerID=int.Parse(values[0].Remove(0,3));
            CustomerID=values[0];
            _balance=double.Parse(values[1]);
            Name=values[2];
            FatherName=values[3];
            Gender=Enum.Parse<Gender>(values[4],true);
            MobileNumber=long.Parse(values[5]);
            DOB=DateTime.ParseExact(values[6],"dd/MM/yyyy",null);
            MailID=values[7];
            Location=values[8];




         }

    }
}