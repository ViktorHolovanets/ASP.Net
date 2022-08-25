namespace WebApplication_MVC_Bind.Models
{
    public class SingletonDb
    {
        private static SingletonDb instance;
        public static  int idEmploy = 0;
        public List<Account> _accounts = new();
        public List<Employ> _employs = new();
        public List<User> _users = new();
        public List<DateTime> MyDateTimes = new();
        private SingletonDb()
        { }
        public static SingletonDb getInstance()
        {
            instance ??= new SingletonDb();
            return instance;
        } 
    }
}
