using DesignPatterns.Models;
using System;

namespace DesignPatterns.ModelBuilder
{
    public abstract class CarBuilder
    {
        public string Brand = "Ford";
        public string Model = "Mustang";
        public string Color = "Red";
        public int Year = DateTime.Now.Year;

        public abstract CarBuilder SetBrand(string brand);
        public abstract CarBuilder SetModel(string model);

        public abstract CarBuilder SetColor(string color);

        public abstract CarBuilder SetYear(int year);
        public Car Build()
        {
            return new Car(Color, Brand, Model, Year);
        }
    }
}