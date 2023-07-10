using DesignPatterns.ModelBuilder;
using DesignPatterns.Models;


namespace DesignPatterns.Infraestructure.FactoryMethod
{
    public class VehicleFactory
    {
        public static Vehicle CreateVehicle(string modelToCreate)
        {

            CarBuilder builder;
            Vehicle vehicle;

            if (modelToCreate.Equals("Escape"))
            {
                builder = new EscapeBuilder();
                vehicle = builder.SetModel("Escape").Build();
            }
            else if (modelToCreate.Equals("Explorer"))
            {
                builder = new ExplorerBuilder();
                vehicle = builder.SetModel("Explorer").Build();
            }
            else
            {
                builder = new MustangBuilder();
                vehicle = builder.Build();
            }

            return vehicle;
        }
    }
}
