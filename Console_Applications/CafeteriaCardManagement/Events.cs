namespace CafeteriaCardManagement
{
    public delegate void EventManager();
    public static class Events
    {
        public static event EventManager starter;
        public static void Subscrie()
        {
            starter=new EventManager(Files.create);
            starter+=new EventManager(Files.ReadFiles);
            Operation.Subscribe();
            starter+=new EventManager(Operation.MainMenu);
            starter+=new EventManager(Files.WriteToFile);
        }
        public static void Starter()
        {
            Subscrie();
            starter();
        }
    }
}