namespace Web_Api.Models
{
    public class Singleton
    {
        private static Singleton instance;
        public List<User> Users { get; set; } = new();
        private Singleton()
        { }
        public static Singleton getInstance()
        {
            instance ??= new Singleton();
            return instance;
        }
    }
}
