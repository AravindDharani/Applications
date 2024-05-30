namespace OnlineFoodDeliveryApplication
{
    public delegate void EventManager();
    /// <summary>
    /// Event class 
    /// </summary>
    public class Events
    {
        public static event EventManager starter;
        /// <summary>
        /// Multiple binding event 
        /// </summary>
        public static void Subscribe()
        {
            starter=new EventManager(Files.Create);
            starter+=new EventManager(Files.ReadFile);
            starter+=new EventManager(Operation.Subscribe);
            starter+=new EventManager(Operation.MainMenu);
            starter+=new EventManager(Files.WriteToFile);
            
        }
        /// <summary>
        /// Call the ethod of Subscribe and starter
        /// </summary>
        public static void Starter()
        {
            Subscribe();
            starter();
        }
        
    }
}