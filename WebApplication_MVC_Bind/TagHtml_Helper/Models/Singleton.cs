namespace TagHtml_Helper.Models
{
    public class Singleton
    {
        private static Singleton instance;
        public List<User> users { get; set; } = new();
        private Singleton()
        { }
        public static Singleton getInstance()
        {
            instance ??= new Singleton();
            return instance;
        }
    }
}
