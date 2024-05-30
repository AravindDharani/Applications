namespace CafeteriaCardManagement
{
    public interface IBalance
    {
          int Balance { get; }

          void WalletRecharge(int money);
          
    }
}