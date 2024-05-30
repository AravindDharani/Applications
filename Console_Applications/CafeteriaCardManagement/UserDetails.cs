using System.Threading;
using System;
namespace CafeteriaCardManagement
{

    public class UserDetails : PersonalDetails, IBalance
    {

        public static int s_userID = 1000;
        public string UserID { get; set; }
        public string WorkStationNumber { get; set; }

        private int _money;

        public int Balance { get { return _money; } }

        public void WalletRecharge(int money)
        {
            _money += money;
        }

        public void Deduct(int money)
        {
            _money -= money;
        }

        public UserDetails(string name, string fatherName, long mobile, string mailID, Gender gender, string workStationNumber, int balance) : base(name, fatherName, gender, mobile, mailID)
        {
            UserID = "SF" + (++s_userID);
            _money = balance;
            WorkStationNumber = workStationNumber;
        }



        public UserDetails(string data)
        {
            string[] values = data.Split(",");
            s_userID = int.Parse(values[0].Remove(0, 2));
            UserID = values[0];
            Name = values[1];
            FatherName = values[2];
            Mobile = long.Parse(values[3]);
            MailID = values[4];
            Gender = Enum.Parse<Gender>(values[5], true);
            WorkStationNumber = values[6];
            _money = int.Parse(values[7]);
        }
    }
}