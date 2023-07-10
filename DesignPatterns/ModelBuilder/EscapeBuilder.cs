namespace DesignPatterns.ModelBuilder
{
    public class EscapeBuilder : CarBuilder
    {

        public override CarBuilder SetBrand(string brand)
        {
            Brand = brand;
            return this;
        }
        public override CarBuilder SetModel(string model)
        {
            Model = model;
            return this;
        }

        public override CarBuilder SetColor(string color)
        {
            Color = color;
            return this;
        }

        public override CarBuilder SetYear(int year)
        {
            Year = year;
            return this;
        }
    }
}
