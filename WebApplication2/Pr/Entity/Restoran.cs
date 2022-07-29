namespace Pr.Entity
{
    public class Restoran
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Number_of_Seats { get; set; }
        public Restoran(string name, string type, int number_of_Seats)
        {
            Name = name;
            Type = type;
            Number_of_Seats = number_of_Seats;
        }
    }
}
