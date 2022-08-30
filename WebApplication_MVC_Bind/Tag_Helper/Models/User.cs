namespace Tag_Helper.Models
{
    public enum Sex
    {
        Man,
        Woman
    }
    public class User
    {
        public string Login { get; set; }
        public string Mail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public Sex sex { get; set; }
        public DateTime Birthday { get; set; }
        public bool IsReceivMems { get; set; }
        public bool IsAgreeConditions { get; set; }

        public void SetBirthday(string? date)
        {
            if (date != "")
                Birthday = DateTime.Parse(date);
        }
    }
}
