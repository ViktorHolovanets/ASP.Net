namespace Pr.Entity
{
    public class Country
    {

        public string Name { get; set; }
        public string Capital { get; set; }
        public double Area { get; set; }
        public Country(string name, string capital, double area)
        {
            Name = name;
            Capital = capital;
            Area = area;
        }

       
    }
}
