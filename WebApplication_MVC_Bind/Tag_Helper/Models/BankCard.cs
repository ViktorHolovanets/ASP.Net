namespace Tag_Helper.Models
{
    public class BankCard
    {
        public string? Id { get; set; }
        public string NumbCard { get; set; } = "";
        public string SurnameClientBank { get; set; } = "";
        public int Month { get; set; }
        public int Year { get; set; }
        public string CVN { get; set; }
    }
}
