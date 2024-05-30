namespace OnlineFoodDeliveryApplication
{
    public interface IBalance
    {
        /// <summary>
        /// Declaring the Property of bAlance
        /// </summary>
        /// <value></value>
         double Balance { get;  }

         /// <summary>
         /// Declearing the Wallet Recharge Method.
         /// </summary>
         /// <param name="money"></param>
         void WalletRecharge(double money);
         /// <summary>
         /// Declearing the DuductBalance Method.
         /// </summary>
         /// <param name="money"></param>
         void DeductBalance(double money);
    }
}